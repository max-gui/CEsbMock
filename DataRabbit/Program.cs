using MockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EsbRedisHelp;
using System.Security.Cryptography;
using HashHelp;
using EsbRabbitHelp;
using System.Threading;

namespace DataRabbit
{
    public class Program
    {
        public static CancellationTokenSource cts = new CancellationTokenSource();

        public static void Main(string[] args)
        {
            initForDb();

            var token = cts.Token;

            var workMethodList = new List<Action<CancellationToken>>()
            {
                UpdateOrAddMockData,
                GetMockData,
                GetByCommentMethod,
                GetAllMethod,
                DeleteMethod,
                GetByKey,
                AddMethod,
                EditerMethod,
                RequestInfoIn,
                RequestInfoOut
            };

            var workerList = new List<Task>();
            var taskTmp = default(Task);

            Action<Action<CancellationToken>> actTmp = (act) =>
                {
                    taskTmp = Task.Factory.StartNew(() =>
                    {
                        act(token);
                    }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    workerList.Add(taskTmp);
                };
            foreach (var worker in workMethodList)
            {
                actTmp(worker);
                actTmp(worker);
            }

            try
            {
                Task.WaitAll(workerList.ToArray());
            }
            catch (AggregateException e)if(e.InnerExceptions.Any(ex=> ex is TaskCanceledException))
            {
                foreach (var v in e.InnerExceptions)
                {
                    IfElseHelp(() => v is TaskCanceledException,
                        () => Console.WriteLine("   TaskCanceledException: Task \{((TaskCanceledException)v).Task.Id}"),//, ((TaskCanceledException)v).Task.Id),
                        () => Console.WriteLine("   Exception: \{v.GetType().Name}"));//, v.GetType().Name));
                }
                Console.WriteLine();
            }
            finally
            {
                RedisHelp.DB.Multiplexer.Close();
            }
        }

        private static T CodeBlockHelp<T>(Func<T> f) => f();
        private static bool IfElseHelp(Func<bool> flag, Action trueBlock, Action falseBlock) 
            =>
            flag() ?
                CodeBlockHelp<bool>(() => { trueBlock(); return true; }) :
                CodeBlockHelp<bool>(() => { falseBlock(); return false; });

        private static bool IfElseHelp(Func<bool> flag, Action trueBlock)
            =>
            flag() ?
                CodeBlockHelp<bool>(() => { trueBlock(); return true; }) :
                false;

        delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);

        static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Recursive<A, R> rec = r => a => f(r(r))(a);
            return rec(rec);
        }


        private static void initForDb()
        {
            Console.WriteLine("waitting for \{nameof(initForDb)}");
            //init for ctrip.soa.esb.asmx
            using (var db = new MockMessageEntity())
            {
                var typeStrTmp = "SOA.ESB.GetReferenceID";
                var esbRti = db.RequestTypeInfos.Where(e => e.RequestType.Equals(typeStrTmp, StringComparison.OrdinalIgnoreCase));

                var rti = default(RequestTypeInfo);
                rti = esbRti.FirstOrDefault() ?? CodeBlockHelp<RequestTypeInfo>(() =>
                {
                    var wsIdTmp = "901101";
                    var esbSti = db.ServiceTypes.Where(e => e.WebServiceId.Equals(wsIdTmp, StringComparison.OrdinalIgnoreCase));

                    var sti = default(ServiceTypeInfo);
                    sti = esbSti.FirstOrDefault() ?? CodeBlockHelp<ServiceTypeInfo>(() =>
                    {
                        sti = new ServiceTypeInfo
                        {
                            WebServiceId = wsIdTmp,
                            WSName = "SOA.ESB1",
                            WsUrl = "http://soa.fws.qa.nt.ctripcorp.com//SOA.ESB//Ctrip.SOA.ESB.asmx"
                        };

                        db.ServiceTypes.Add(sti);

                        return sti;
                    });
                    //Func<int, int> fib = Y<int, int>(f => n => n > 1 ? f(n - 1) + f(n - 2) : n);

                    //Console.WriteLine(fib(6));

                    rti = new RequestTypeInfo
                    {
                        RequestType = typeStrTmp,
                        ServiceType = sti
                    };

                    db.RequestTypeInfos.Add(rti);

                    db.SaveChanges();

                    return rti;
                });
            }

            Console.WriteLine("the \{nameof(initForDb)} has been ok");
        }

        private static void Send(string channelName, Action<string> messageAct,CancellationToken ct)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(channelName, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(channelName, true, consumer);

                    Console.WriteLine(" [*] \{channelName} Waiting for messages.");
                    while (true)
                    {
                        Thread.SpinWait(1000);

                        ct.ThrowIfCancellationRequested();
                        //if (ct.IsCancellationRequested == true)
                        //{
                        //    Console.WriteLine("Task {0} was cancelled before it got started.",
                        //      Task.CurrentId);
                        //    //ct.ThrowIfCancellationRequested();
                        //    break;// ct.ThrowIfCancellationRequested();
                        //}
                        var ea = default(BasicDeliverEventArgs);
                        //var flag = consumer.Queue.Dequeue(1000, out ea);

                        IfElseHelp(() => consumer.Queue.Dequeue(1000, out ea),
                            () =>
                            {
                                var body = ea.Body;
                                var message = Encoding.UTF8.GetString(body);

                                try
                                {
                                    messageAct(message);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(" [.] \{e.Message}");
                                }

                                Console.WriteLine(" [x] Received \{message}");
                            });                        
                    }
                }
            }
        }

        private static void Rpc(string FromChannel, Func<string, string> messageAct,CancellationToken ct)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(FromChannel, false, false, false, null);
                    channel.BasicQos(0, 1, false);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(FromChannel, false, consumer);
                    Console.WriteLine(" [x] \{FromChannel} Awaiting RPC requests");//,FromChannel));


                    while (true)
                    {
                        Thread.SpinWait(1000);
                        ct.ThrowIfCancellationRequested();
                        //if (ct.IsCancellationRequested == true)
                        //{
                        //    Console.WriteLine("Task {0} was cancelled before it got started.",
                        //         Task.CurrentId);
                        //    //ct.ThrowIfCancellationRequested();
                        //    break;// ct.ThrowIfCancellationRequested();
                        //}

                        var ea = default(BasicDeliverEventArgs);
                        //var flag = consumer.Queue.Dequeue(1000,out ea);

                        IfElseHelp(() => consumer.Queue.Dequeue(1000, out ea),
                            () =>
                            {
                                var body = ea.Body;
                                var props = ea.BasicProperties;
                                var replyProps = channel.CreateBasicProperties();
                                replyProps.CorrelationId = props.CorrelationId;

                                string res = string.Empty;

                                try
                                {
                                    var message = Encoding.UTF8.GetString(body);
                                    res = messageAct(message);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(" [.] \{e.Message}");// + e.Message);
                                }
                                finally
                                {
                                    var responseBytes =
                                        Encoding.UTF8.GetBytes(res);
                                    channel.BasicPublish("", props.ReplyTo, replyProps,
                                                         responseBytes);
                                    channel.BasicAck(ea.DeliveryTag, false);
                                }
                            });
                    }
                }
            }
        }

        private static void UpdateOrAddMockData(CancellationToken ct)=>        
            Send(PipeName.EsbUpdateOrAddMockData.ToString(), (message) =>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

                Save(mockMessageTmp, (db, infoTmp, rtiTmp) =>
                {
                    infoTmp = infoTmp ?? new MockMessage
                    {
                        InTime = DateTime.Now,
                        RequestXml = mockMessageTmp.RequestXml,
                        ResponseXml = mockMessageTmp.ResponseXml,
                        RequestType = rtiTmp,
                        LastModifyTime = DateTime.MaxValue,
                        Comment = string.IsNullOrEmpty(mockMessageTmp.Comment) ? mockMessageTmp.RequestType.ServiceType.WebServiceId : mockMessageTmp.Comment, //commentFlag ? string.Empty:mockMessageTmp.Comment,
                        Timeout = mockMessageTmp.Timeout,
                        KeyInfo = mockMessageTmp.KeyInfo
                    }; 

                    infoTmp.ResponseXml = mockMessageTmp.ResponseXml;
                    infoTmp.LastModifyTime = DateTime.Now;

                    db.MockMessages.Add(infoTmp);
                    db.SaveChanges();

                    CacheToRedis(infoTmp);
                });
            }, ct);
        

        private static void RequestInfoIn(CancellationToken ct)=>
            Send(PipeName.EsbRequestInfoIn.ToString(), (message) =>
            {
                var typeTmp = JsonConvert.DeserializeObject<RequestTypeInfo>(message);

                using (var db = new MockMessageEntity())
                {
                    var stiFromDb =
                        from info in db.ServiceTypes
                        where info.WebServiceId.Equals(typeTmp.ServiceType.WebServiceId)
                        select info;

                    var stiTmp = default(ServiceTypeInfo);
                    stiTmp = stiFromDb.FirstOrDefault() ?? CodeBlockHelp<ServiceTypeInfo>(() =>
                     {
                         stiTmp = new ServiceTypeInfo
                         {
                             WebServiceId = typeTmp.ServiceType.WebServiceId,
                             WSName = typeTmp.ServiceType.WSName,
                             WsUrl = typeTmp.ServiceType.WsUrl
                         };

                         db.ServiceTypes.Add(stiTmp);

                         return stiTmp;
                     });
                    

                    var rtiFromDb =
                        from info in db.RequestTypeInfos
                        where info.RequestType.Equals(typeTmp.RequestType)
                        select info;

                    var rtiTmp = default(RequestTypeInfo);
                    rtiTmp = rtiFromDb.FirstOrDefault() ?? CodeBlockHelp<RequestTypeInfo>(() =>
                    {
                        rtiTmp = new RequestTypeInfo
                        {
                            RequestType = typeTmp.RequestType
                        };

                        db.RequestTypeInfos.Add(rtiTmp);

                        return rtiTmp;
                    });

                    rtiTmp.ServiceType = stiTmp;

                    db.SaveChanges();
                    var valueTmp = JsonConvert.SerializeObject(rtiTmp);
                    RedisHelp.DB.StringSet(typeTmp.RequestType.ToLower(), valueTmp, expiry: new TimeSpan(1, 0, 0));
                }
            },ct);

        private static void RequestInfoOut(CancellationToken ct) =>
            Rpc(PipeName.EsbRequestInfoOut.ToString(), (message) =>
            {
                var typeStrTmp = message;
                var res = string.Empty;

                res = RedisHelp.DB.StringGet(typeStrTmp.ToLower()).ToString() ?? CodeBlockHelp<string>(() =>
                 {
                     using (var db = new MockMessageEntity())
                     {
                         var rtiFromDb =
                             db.RequestTypeInfos.Include(e => e.ServiceType).Where(
                                 r => r.RequestType.Equals(typeStrTmp, StringComparison.OrdinalIgnoreCase));

                         IfElseHelp(() => rtiFromDb.Count() > 0,
                             () => res = JsonConvert.SerializeObject(rtiFromDb.First()));
                     }

                     return res;
                 });

                return res;
            }, ct);

        private static void AddMethod(CancellationToken ct) =>
            Rpc(PipeName.EsbNewData.ToString(),(message)=>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);
                var idTmp = string.Empty;

                Save(mockMessageTmp, ((db, infoTmp, rtiTmp) =>
                {
                    infoTmp = infoTmp ?? CodeBlockHelp<MockMessage>(() =>
                         {
                             infoTmp = new MockMessage
                             {
                                 InTime = DateTime.Now,
                                 RequestXml = mockMessageTmp.RequestXml,
                                 ResponseXml = mockMessageTmp.ResponseXml,
                                 RequestType = rtiTmp,
                                 LastModifyTime = DateTime.MaxValue,
                                 Comment = string.IsNullOrEmpty(mockMessageTmp.Comment) ? mockMessageTmp.RequestType.ServiceType.WebServiceId : mockMessageTmp.Comment, //commentFlag ? string.Empty:mockMessageTmp.Comment,
                                 Timeout = mockMessageTmp.Timeout,
                                 KeyInfo = mockMessageTmp.RequestXml.Message2KeyWord()
                             };

                             db.MockMessages.Add(infoTmp);


                             db.SaveChanges();

                             CacheToRedis(infoTmp);

                             idTmp = infoTmp.KeyInfo;

                             return infoTmp;
                         });                    
                }));
                
                return idTmp;
            }, ct);

        private static void EditerMethod(CancellationToken ct) =>
            Rpc(PipeName.EsbEditData.ToString(), (message) =>
                {
                    var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);
                    var idTmp = string.Empty;

                    using (var db = new MockMessageEntity())
                    {

                        var infoFromDb =
                        from info in db.MockMessages
                        where
                            info.KeyInfo.Equals(mockMessageTmp.KeyInfo)
                        select
                            info;

                        var infoTmp = infoFromDb.FirstOrDefault();// infoFromDb.Count() > 0 ? infoFromDb.First() : null;

                        IfElseHelp(() => null != infoTmp,
                            () =>
                            {
                                if (!string.IsNullOrEmpty(mockMessageTmp.ResponseXml))
                                {
                                    infoTmp.ResponseXml = mockMessageTmp.ResponseXml;
                                }

                                if (null != mockMessageTmp.Comment)
                                    infoTmp.Comment = mockMessageTmp.Comment;

                                if (!TimeSpan.MinValue.Equals(mockMessageTmp.Timeout))
                                    infoTmp.Timeout = mockMessageTmp.Timeout;

                                infoTmp.LastModifyTime = DateTime.Now;

                                db.SaveChanges();

                                CacheToRedis(infoTmp);

                                idTmp = infoTmp.KeyInfo;
                            });
                    }

                    return idTmp;
                },ct);                       

        private static void GetMockData(CancellationToken ct)=>
            Rpc(PipeName.EsbGetMockData.ToString(), (message) =>
            {
                var requestKeyTmp = message;

                var redis = RedisHelp.DB;
                var res = string.Empty;
                
                Func<string, string> retFromCache =
                    inVar =>
                    {
                        var timeTmp = redis.HashGetAsync(requestKeyTmp, "timeout")?.Result.ToString() ?? string.Empty;

                        var tmp =
                                    new
                                    {
                                        ResponseXml = inVar,
                                        Timeout = JsonConvert.DeserializeObject<TimeSpan>(timeTmp)
                                    };

                        inVar = JsonConvert.SerializeObject(tmp);

                        RedisHelp.DB.KeyExpire(requestKeyTmp, new TimeSpan(1, 0, 0));

                        return inVar;
                    };

                res = redis.HashGetAsync(requestKeyTmp, "response")?.Result.ToString().Func2Extension(retFromCache) ?? CodeBlockHelp<string>(() =>
                {
                    using (var db = new MockMessageEntity())
                    {
                        var m =
                            from info in db.MockMessages
                            where
                                info.KeyInfo.Equals(requestKeyTmp)
                            select
                                info;

                        if (m.Count() > 0)
                        {
                            var messageTmp = m.First();
                            var tmp =
                                new
                                {
                                    ResponseXml = messageTmp.ResponseXml,
                                    Timeout = messageTmp.Timeout
                                };

                            res = JsonConvert.SerializeObject(tmp);

                            CacheToRedis(messageTmp);
                        }
                    }

                    return res;
                });

                return res;
            }, ct);

        private static void GetByKey(CancellationToken ct)=>
            Rpc(PipeName.rpc_getByKey.ToString(), (message) =>
            {
                string res = string.Empty;

                //var mockMessageTmp = JObject.Parse(message);

                //var requestTypeTmp = mockMessageTmp["type"].ToString();
                //var requestXMLTmp = mockMessageTmp["request"].ToString();
                //var requestKeyTmp = mockMessageTmp["key"].ToString();
                var requestKeyTmp = message;

                using (var db = new MockMessageEntity())
                {
                    var messageFromDb = db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType).
                        Where(e => e.KeyInfo.Equals(requestKeyTmp));

                    res = messageFromDb.FirstOrDefault()?.ToJson() ?? string.Empty;
                }

                return res;
            }, ct);

        private static void GetByCommentMethod(CancellationToken ct)=>
            Rpc(PipeName.rpc_getByComment.ToString(), (commentTmp) =>
            {
                string res = string.Empty;
                
                using (var db = new MockMessageEntity())
                {
                    var messageFromDb = db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType).
                        Where(e => e.Comment.Equals(commentTmp));

                    res = messageFromDb.Count() > 0 ? messageFromDb.ToList().ToJson() : string.Empty;                    
                }

                return res;
            }, ct);

        private static void GetAllMethod(CancellationToken ct)=>
            Rpc(PipeName.rpc_get_all.ToString(), (commentTmp) =>
            {
                string res = string.Empty;

                using (var db = new MockMessageEntity())
                {
                    var messageFromDb =
                        db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType);

                    res = messageFromDb.Count() > 0 ? messageFromDb.ToList().ToJson() : string.Empty;
                }

                return res;
            }, ct);

        private static void DeleteMethod(CancellationToken ct) =>
            Rpc(PipeName.rpc_delete.ToString(), (message) =>
            {
                var requestKeyTmp = message;

                var flag = false;
                using (var db = new MockMessageEntity())
                {
                    var messageFromDb =
                        from info in db.MockMessages
                        where
                            info.KeyInfo.Equals(requestKeyTmp)
                        select
                            info;

                    var messageToDel = messageFromDb.FirstOrDefault();

                    IfElseHelp(() => null != messageToDel,
                        () =>
                        {
                            db.MockMessages.Remove(messageToDel);
                            db.SaveChanges();

                            RedisHelp.DB.KeyDelete(requestKeyTmp);
                            flag = true;
                        });                    
                }

                var res = JsonConvert.SerializeObject(flag);
                return res;
            }, ct);

        private static void Save(MockMessage mockMessageTmp, Action<MockMessageEntity, MockMessage, RequestTypeInfo> act)
        {
            using (var db = new MockMessageEntity())
            {
                var stiFromDb =
                    from info in db.ServiceTypes
                    where info.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId)
                    select info;

                var stiTmp = default(ServiceTypeInfo);// stiFromDb.Count() > 0 ? stiFromDb.First() : null;
                stiTmp = stiFromDb.FirstOrDefault() ?? CodeBlockHelp<ServiceTypeInfo>(() =>
                 {
                     stiTmp = new ServiceTypeInfo
                     {
                         WebServiceId = mockMessageTmp.RequestType.ServiceType.WebServiceId,
                         WSName = mockMessageTmp.RequestType.ServiceType.WSName,
                         WsUrl = mockMessageTmp.RequestType.ServiceType.WsUrl
                     };

                     db.ServiceTypes.Add(stiTmp);

                     return stiTmp;
                 });

                var rtiFromDb =
                    from info in db.RequestTypeInfos
                    where info.RequestType.Equals(mockMessageTmp.RequestType.RequestType)
                    select info;

                var rtiTmp = default(RequestTypeInfo);// rtiFromDb.Count() > 0 ? rtiFromDb.First() : null;
                rtiTmp = rtiFromDb.FirstOrDefault() ?? CodeBlockHelp<RequestTypeInfo>(() =>
                {
                    rtiTmp = new RequestTypeInfo
                    {
                        RequestType = mockMessageTmp.RequestType.RequestType
                    };

                    db.RequestTypeInfos.Add(rtiTmp);
                    return rtiTmp;
                });

                rtiTmp.ServiceType = stiTmp;

                var messageFromDb =
                from info in db.MockMessages
                where
                    info.KeyInfo.Equals(mockMessageTmp.KeyInfo)
                select
                    info;

                var infoTmp = messageFromDb.FirstOrDefault();// m.Count() > 0 ? m.First() : null;

                act(db, infoTmp, rtiTmp);


            }
        }

        private static void CacheToRedis(MockMessage mockMessageTmp)
        {
            RedisHelp.DB.HashSetAsync(mockMessageTmp.KeyInfo, new HashEntry[]{
                new HashEntry("request",mockMessageTmp.RequestXml),
                new HashEntry("response",mockMessageTmp.ResponseXml),
                new HashEntry("timeout",JsonConvert.SerializeObject(mockMessageTmp.Timeout))});
            RedisHelp.DB.KeyExpireAsync(mockMessageTmp.KeyInfo, expiry: new TimeSpan(1, 0, 0));
        }
    }

    public static class JsonHelp
    {
        public static string ToJson<T>(this T inVar) =>
            JsonConvert.SerializeObject(inVar);
    }

    public static class FuncHelp
    {
        public static Tout Func2Extension<Tin,Tout>(this Tin inVar,Func<Tin,Tout> f) =>
            f(inVar);
    }
}
