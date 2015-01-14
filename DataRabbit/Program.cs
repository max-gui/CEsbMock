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
                    },token,TaskCreationOptions.LongRunning,TaskScheduler.Default);
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
            catch(AggregateException e)
            {
                foreach (var v in e.InnerExceptions)
                {
                    if (v is TaskCanceledException)
                        Console.WriteLine("   TaskCanceledException: Task {0}",
                                          ((TaskCanceledException)v).Task.Id);
                    else
                        Console.WriteLine("   Exception: {0}", v.GetType().Name);
                }
                Console.WriteLine();
            }

            RedisHelp.DB.Multiplexer.Close();
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

                    Console.WriteLine(string.Format(" [*] {0} Waiting for messages.",channelName));
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
                        var flag = consumer.Queue.Dequeue(1000, out ea);

                        if (flag)
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);

                            try
                            {
                                messageAct(message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(" [.] " + e.Message);
                            }

                            Console.WriteLine(" [x] Received {0}", message);
                        }
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
                    Console.WriteLine(string.Format(" [x] {0} Awaiting RPC requests",FromChannel));


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
                        var flag = consumer.Queue.Dequeue(1000,out ea);

                        if (flag)
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
                                Console.WriteLine(" [.] " + e.Message);
                            }
                            finally
                            {
                                var responseBytes =
                                    Encoding.UTF8.GetBytes(res);
                                channel.BasicPublish("", props.ReplyTo, replyProps,
                                                     responseBytes);
                                channel.BasicAck(ea.DeliveryTag, false);
                            }
                        }
                        //});
                    }
                }
            }
        }

        private static void UpdateOrAddMockData(CancellationToken ct)
        {
            Send(PipeName.EsbUpdateOrAddMockData.ToString(), (message) =>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

                Save(mockMessageTmp, (db, infoTmp, rtiTmp) =>
                {
                    if (null == infoTmp)
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
                            KeyInfo = mockMessageTmp.KeyInfo
                        };
                    }

                    infoTmp.ResponseXml = mockMessageTmp.ResponseXml;
                    infoTmp.LastModifyTime = DateTime.Now;

                    db.MockMessages.Add(infoTmp);


                    db.SaveChanges();

                    CacheToRedis(infoTmp);
                });
            }, ct);
        }

        private static void RequestInfoIn(CancellationToken ct)
        {
            Send(PipeName.EsbRequestInfoIn.ToString(), (message) =>
            {
                var typeTmp = JsonConvert.DeserializeObject<RequestTypeInfo>(message);

                using (var db = new MockMessageEntity())
                {
                    var b =
                        from info in db.ServiceTypes
                        where info.WebServiceId.Equals(typeTmp.ServiceType.WebServiceId)
                        select info;

                    var stiTmp = b.Count() > 0 ? b.First() : null;
                    if (null == stiTmp)
                    {
                        stiTmp = new ServiceTypeInfo
                        {
                            WebServiceId = typeTmp.ServiceType.WebServiceId,
                            WSName = typeTmp.ServiceType.WSName,
                            WsUrl = typeTmp.ServiceType.WsUrl
                        };

                        db.ServiceTypes.Add(stiTmp);
                    }

                    var c =
                        from info in db.RequestTypeInfos
                        where info.RequestType.Equals(typeTmp.RequestType)
                        select info;

                    var rtiTmp = c.Count() > 0 ? c.First() : null;
                    if (null == rtiTmp)
                    {
                        rtiTmp = new RequestTypeInfo
                        {
                            RequestType = typeTmp.RequestType
                        };

                        db.RequestTypeInfos.Add(rtiTmp);
                    }

                    rtiTmp.ServiceType = stiTmp;

                    db.SaveChanges();
                    var valueTmp = JsonConvert.SerializeObject(rtiTmp);
                    RedisHelp.DB.StringSet(typeTmp.RequestType.ToLower(), valueTmp, expiry: new TimeSpan(1, 0, 0));
                }
            },ct);
        }

        private static void RequestInfoOut(CancellationToken ct)
        {
            Rpc(PipeName.EsbRequestInfoOut.ToString(), (message) =>
            {
                var typeStrTmp = message;
                var res = string.Empty;

                res = RedisHelp.DB.StringGet(typeStrTmp.ToLower()).ToString();
                res = string.IsNullOrEmpty(res) ? string.Empty : res;
                if (string.IsNullOrEmpty(res))
                {
                    using (var db = new MockMessageEntity())
                    {
                        var n =
                            from info in db.RequestTypeInfos
                            where info.RequestType.Equals(typeStrTmp, StringComparison.OrdinalIgnoreCase)
                            select info;

                        if (n.Count() > 0)
                        {
                            var m = n.First();
                            res = JsonConvert.SerializeObject(m);
                        }
                    }
                }

                return res;
            }, ct);
        }

        private static void AddMethod(CancellationToken ct)
        {
            Rpc(PipeName.EsbNewData.ToString(),(message)=>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);
                var idTmp = string.Empty;
                Save(mockMessageTmp, ((db, infoTmp, rtiTmp) =>
                {
                    if (null == infoTmp)
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
                    }
                }));
                
                return idTmp;
            }, ct);

            //Send(PipeName.EsbNewData.ToString(), (message) =>
            //{
            //    var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

            //    Save(mockMessageTmp, ((db, infoTmp, rtiTmp) =>
            //    {
            //        if (null == infoTmp)
            //        {
            //            infoTmp = new MockMessage
            //            {
            //                InTime = DateTime.Now,
            //                RequestXml = mockMessageTmp.RequestXml,
            //                ResponseXml = mockMessageTmp.ResponseXml,
            //                RequestType = rtiTmp,
            //                LastModifyTime = DateTime.MaxValue,
            //                Comment = string.IsNullOrEmpty(mockMessageTmp.Comment) ? mockMessageTmp.RequestType.ServiceType.WebServiceId : mockMessageTmp.Comment, //commentFlag ? string.Empty:mockMessageTmp.Comment,
            //                Timeout = mockMessageTmp.Timeout,
            //                KeyInfo = mockMessageTmp.KeyInfo
            //            };

            //            db.MockMessages.Add(infoTmp);


            //            db.SaveChanges();

            //            CacheToRedis(infoTmp);
            //        }
            //    }));
            //});
        }

        private static void EditerMethod(CancellationToken ct)
        {
            Rpc(PipeName.EsbEditData.ToString(), (message) =>
                {
                    var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);
                    var idTmp = string.Empty;

                    using (var db = new MockMessageEntity())
                    {

                        var m =
                        from info in db.MockMessages
                        where
                            info.KeyInfo.Equals(mockMessageTmp.KeyInfo)
                        select
                            info;

                        var infoTmp = m.Count() > 0 ? m.First() : null;

                        if (null != infoTmp)
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
                        }
                    }

                    return idTmp;
                },ct);                              
        }

        private static void GetMockData(CancellationToken ct)
        {
            Rpc(PipeName.EsbGetMockData.ToString(), (message) =>
            {
                var mockMessageTmp = JObject.Parse(message);

                var requestTypeTmp = mockMessageTmp["type"].ToString();
                var requestXMLTmp = mockMessageTmp["request"].ToString();
                var requestKeyTmp = mockMessageTmp["key"].ToString();

                var redis = RedisHelp.DB;
                var res = redis.HashGetAsync(requestKeyTmp, "response").Result.ToString();
                res = string.IsNullOrEmpty(res) ? string.Empty : res;
                var timeTmp = redis.HashGetAsync(requestKeyTmp, "timeout").Result.ToString();

                if (string.IsNullOrEmpty(res))
                {
                    using (var db = new MockMessageEntity())
                    {
                        var m =
                            from info in db.MockMessages
                            where
                                info.RequestType.RequestType.Equals(requestTypeTmp) &&
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
                }
                else
                {
                    var tmp =
                                new
                                {
                                    ResponseXml = res,
                                    Timeout = JsonConvert.DeserializeObject<TimeSpan>(timeTmp)
                                };

                    res = JsonConvert.SerializeObject(tmp);

                    RedisHelp.DB.KeyExpire(requestKeyTmp, new TimeSpan(1, 0, 0));
                }

                return res;
            }, ct);
        }

        private static void GetByKey(CancellationToken ct)
        {
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
                    var m = db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType).
                        Where(e => e.KeyInfo.Equals(requestKeyTmp));

                    if (m.Count() > 0)
                    {
                        res = JsonConvert.SerializeObject(m.First());
                    }
                }

                return res;
            }, ct);
        }

        private static void GetByCommentMethod(CancellationToken ct)
        {
            Rpc(PipeName.rpc_getByComment.ToString(), (commentTmp) =>
            {
                string res = string.Empty;

                var resTmp = default(List<MockMessage>);
                using (var db = new MockMessageEntity())
                {
                    var m = db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType).
                        Where(e => e.Comment.Equals(commentTmp));

                    if (m.Count() > 0)
                    {
                        resTmp = m.ToList();
                        res = JsonConvert.SerializeObject(resTmp);
                    }
                }

                return res;
            }, ct);
        }
        private static void GetAllMethod(CancellationToken ct)
        {
            Rpc(PipeName.rpc_get_all.ToString(), (commentTmp) =>
            {
                string res = string.Empty;

                var resTmp = default(List<MockMessage>);
                using (var db = new MockMessageEntity())
                {
                    var m =
                        db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType);

                    if (m.Count() > 0)
                    {
                        resTmp = m.ToList();
                        res = JsonConvert.SerializeObject(resTmp);
                    }
                }

                return res;
            }, ct);
        }

        private static void DeleteMethod(CancellationToken ct)
        {
            Rpc(PipeName.rpc_delete.ToString(), (message) =>
            {
                //var mockMessageTmp = JObject.Parse(message);

                //var requestTypeTmp = mockMessageTmp["type"].ToString();
                //var requestXMLTmp = mockMessageTmp["request"].ToString();
                //var requestKeyTmp = mockMessageTmp["key"].ToString();
                var requestKeyTmp = message;

                var flag = false;
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
                        db.MockMessages.Remove(m.FirstOrDefault());
                        db.SaveChanges();

                        RedisHelp.DB.KeyDelete(requestKeyTmp);
                        flag = true;
                    }
                }

                var res = JsonConvert.SerializeObject(flag);
                return res;
            }, ct);
        }

        private static void Save(MockMessage mockMessageTmp, Action<MockMessageEntity, MockMessage, RequestTypeInfo> act)
        {
            using (var db = new MockMessageEntity())
            {
                var b =
                    from info in db.ServiceTypes
                    where info.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId)
                    select info;

                var stiTmp = b.Count() > 0 ? b.First() : null;
                if (null == stiTmp)
                {
                    stiTmp = new ServiceTypeInfo
                    {
                        WebServiceId = mockMessageTmp.RequestType.ServiceType.WebServiceId,
                        WSName = mockMessageTmp.RequestType.ServiceType.WSName,
                        WsUrl = mockMessageTmp.RequestType.ServiceType.WsUrl
                    };

                    db.ServiceTypes.Add(stiTmp);
                }

                var c =
                    from info in db.RequestTypeInfos
                    where info.RequestType.Equals(mockMessageTmp.RequestType.RequestType)
                    select info;

                var rtiTmp = c.Count() > 0 ? c.First() : null;
                if (null == rtiTmp)
                {
                    rtiTmp = new RequestTypeInfo
                    {
                        RequestType = mockMessageTmp.RequestType.RequestType
                    };

                    db.RequestTypeInfos.Add(rtiTmp);
                }

                rtiTmp.ServiceType = stiTmp;

                var m =
                from info in db.MockMessages
                where
                    info.KeyInfo.Equals(mockMessageTmp.KeyInfo)
                select
                    info;

                var infoTmp = m.Count() > 0 ? m.First() : null;

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
}
