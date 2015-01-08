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

namespace DataRabbit
{
    class Program
    {
        private static RedisHelp RSHelp = new RedisHelp();
        static void Main(string[] args)
        {
            //var rpcTask1 = new TaskFactory().StartNew(() =>
            //{
            //    RpcMethod(); 
            //});

            //var rpcTask2 = new TaskFactory().StartNew(() =>
            //{
            //    RpcMethod();
            //});

            //var queWorkerTask1 = new TaskFactory().StartNew(() =>
            //{
            //    WorkerMethod();
            //});

            //var queWorkerTask2 = new TaskFactory().StartNew(() =>
            //{
            //    WorkerMethod();
            //});

            //var taskList = new Task[]
            //{
            //    rpcTask1,rpcTask2,queWorkerTask1,queWorkerTask2
            //};
            //Console.WriteLine(EsbRabbitHelp.PipeName.EsbEditData.ToString());
            var workMethodList = new List<Action>()
            {
                UpdateOrAddMockData,
                GetMockData,
                GetByCommentMethod,
                GetAllMethod,
                DeleteMethod,
                GetByRequest,
                AddMethod,
                EditerMethod,
                RequestInfoIn,
                RequestInfoOut
            };

            var workerList = new List<Task>();
            var taskTmp = default(Task);

            Action<Action> actTmp = (act) =>
                {
                    taskTmp = new TaskFactory().StartNew(() =>
                    {
                        act();                        
                    });
                    workerList.Add(taskTmp);
                };
            foreach (var worker in workMethodList)
            {
                actTmp(worker);
                actTmp(worker);
            }

            //GetByCommentMethod GetAllMethod DeleteMethod
            Task.WaitAll(workerList.ToArray());
        }

        private static void Send(string channelName, Action<string> messageAct)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(channelName, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(channelName, true, consumer);

                    Console.WriteLine(" [*] Waiting for messages." +
                                             "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        messageAct(message);

                        Console.WriteLine(" [x] Received {0}", message);
                    }
                }
            }
        }

        private static void Rpc(string FromChannel, Func<string, string> messageAct)
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
                    Console.WriteLine(" [x] Awaiting RPC requests");


                    while (true)
                    {
                        var ea =
                            (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var props = ea.BasicProperties;
                        var replyProps = channel.CreateBasicProperties();
                        replyProps.CorrelationId = props.CorrelationId;

                        //var repTask = Task.Factory.StartNew(() =>
                        //{
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
                        //});
                    }
                }
            }
        }

        private static void UpdateOrAddMockData()
        {
            Send(PipeName.EsbUpdateOrAddMockData.ToString(), (message) =>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

                Save(mockMessageTmp, (infoTmp) =>
                {
                    infoTmp.ResponseXml = mockMessageTmp.ResponseXml;
                    infoTmp.LastModifyTime = DateTime.Now;
                });
            });
        }

        private static void RequestInfoIn()
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
                        //&& info.ServiceType.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId)
                        select info;

                    var rtiTmp = c.Count() > 0 ? c.First() : null;
                    if (null == rtiTmp)
                    {
                        rtiTmp = new RequestTypeInfo
                        {
                            RequestType = typeTmp.RequestType
                            //ServiceType = stiTmp
                        };

                        db.RequestTypeInfos.Add(rtiTmp);
                    }

                    rtiTmp.ServiceType = stiTmp;

                    db.SaveChanges();
                    var valueTmp = JsonConvert.SerializeObject(rtiTmp);
                    RSHelp.DB.StringSet(typeTmp.RequestType.ToLower(), valueTmp, expiry: new TimeSpan(1, 0, 0));
                }

                //Save(typeTmp, (infoTmp) =>
                //{
                //    infoTmp.ResponseXml = typeTmp.ResponseXml;
                //    infoTmp.LastModifyTime = DateTime.Now;
                //});
            });
        }

        private static void RequestInfoOut()
        {
            Rpc(PipeName.EsbRequestInfoOut.ToString(), (message) =>
            {
                var typeStrTmp = message;
                var res = string.Empty;

                res = RSHelp.DB.StringGet(typeStrTmp.ToLower()).ToString();
                if (string.IsNullOrEmpty(res))
                {
                    using (var db = new MockMessageEntity())
                    {
                        var n =
                            from info in db.RequestTypeInfos
                            where info.RequestType.Equals(typeStrTmp,StringComparison.OrdinalIgnoreCase)
                            select info;

                        if (n.Count() > 0)
                        {
                            var m = n.First();
                            res = JsonConvert.SerializeObject(m);
                        }
                    }
                }

                return res;
            });
        }

        private static void AddMethod()
        {
            Send(PipeName.EsbNewData.ToString(), (message) =>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

                Save(mockMessageTmp, (infoTmp) =>
                {

                });
            });
        }

        private static void EditerMethod()
        {
            Send(PipeName.EsbEditData.ToString(), (message) =>
            {
                var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

                Save(mockMessageTmp, (infoTmp) =>
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
                });
            });
        }

        private static void GetMockData()
        {
            Rpc(PipeName.EsbGetMockData.ToString(), (message) =>
            {
                string res = string.Empty;

                var mockMessageTmp = JObject.Parse(message);// JsonConvert.DeserializeObject<MockMessage>(message);

                var requestTypeTmp = mockMessageTmp["type"].ToString();
                var requestXMLTmp = mockMessageTmp["request"].ToString();
                var requestKeyTmp = mockMessageTmp["key"].ToString();

                var redis = RSHelp.DB;
                //var keyTmp = reqXmlToCompare.Message2KeyWord();
                var response = redis.HashGetAsync(requestKeyTmp, "response").Result.ToString();// .StringGet(reqXmlToCompare.GetHashCode().ToString());
                
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
                                    ResponseXml = response,
                                    Timeout = JsonConvert.DeserializeObject<TimeSpan>(timeTmp)
                                };

                    res = JsonConvert.SerializeObject(tmp);

                    RSHelp.DB.KeyExpire(requestKeyTmp, new TimeSpan(1, 0, 0));
                    //CacheToRedis(messageTmp);
                }

                return res;
            });
        }

        private static void GetByRequest()
        {
            Rpc(PipeName.rpc_getByRequest.ToString(), (message) =>
            {
                string res = string.Empty;

                var mockMessageTmp = JObject.Parse(message);// JsonConvert.DeserializeObject<MockMessage>(message);

                var requestTypeTmp = mockMessageTmp["type"].ToString();
                var requestXMLTmp = mockMessageTmp["request"].ToString();
                var requestKeyTmp = mockMessageTmp["key"].ToString();

                using (var db = new MockMessageEntity())
                {
                    var m = db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType).
                        Where(e => e.KeyInfo.Equals(requestKeyTmp));
                    //from info in db.MockMessages
                    //where
                    //    info.RequestType.RequestType.Equals(requestTypeTmp) &&
                    //    info.RequestXml.Equals(requestXMLTmp)
                    //select
                    //    info;

                    if (m.Count() > 0)
                    {
                        res = JsonConvert.SerializeObject(m.First());
                    }
                }

                return res;
            });
        }

        private static void GetByCommentMethod()
        {
            Rpc(PipeName.rpc_getByComment.ToString(), (commentTmp) =>
            {
                string res = string.Empty;

                var resTmp = default(List<MockMessage>);
                using (var db = new MockMessageEntity())
                {
                    var m = db.MockMessages.Include(e => e.RequestType).Include(e => e.RequestType.ServiceType).
                        Where(e => e.Comment.Equals(commentTmp));
                    //from info in db.MockMessages
                    //where
                    //    info.Comment.Equals(commentTmp)
                    //select
                    //    info;

                    if (m.Count() > 0)
                    {
                        resTmp = m.ToList();
                        res = JsonConvert.SerializeObject(resTmp);
                    }
                }

                return res;
            });
        }
        private static void GetAllMethod()
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
                        //Console.WriteLine(m.FirstOrDefault().RequestType.ServiceType);
                        resTmp = m.ToList();
                        res = JsonConvert.SerializeObject(resTmp);
                    }
                }

                return res;
            });
        }

        private static void DeleteMethod()
        {
            Send(PipeName.rpc_delete.ToString(), (message) =>
            {
                var mockMessageTmp = JObject.Parse(message);// JsonConvert.DeserializeObject<MockMessage>(message);

                var requestTypeTmp = mockMessageTmp["type"].ToString();
                var requestXMLTmp = mockMessageTmp["request"].ToString();
                var requestKeyTmp = mockMessageTmp["key"].ToString();


                using (var db = new MockMessageEntity())
                {
                    var m =
                        from info in db.MockMessages
                        where
                            //info.RequestType.RequestType.Equals(requestTypeTmp) &&
                            info.KeyInfo.Equals(requestKeyTmp)
                        select
                            info;

                    if (m.Count() > 0)
                    {
                        db.MockMessages.Remove(m.FirstOrDefault());
                        db.SaveChanges();

                        //ConfigurationOptions config = new ConfigurationOptions
                        //{
                        //    EndPoints =
                        //        {
                        //            { "10.2.24.151", 6388}
                        //        }
                        //};

                        //var redis = ConnectionMultiplexer.Connect(config).GetDatabase(10);
                        
                        //var cacheValue = new
                        //{
                        //    request = mockMessageTmp.RequestXml,
                        //    response = mockMessageTmp.ResponseXml
                        //};
                        //var cacheValueStr = JsonConvert.SerializeObject(cacheValue);
                        //redis.set

                        RSHelp.DB.KeyDelete(requestKeyTmp);
                    }
                }
            });
        }

        private static void Save(MockMessage mockMessageTmp, Action<MockMessage> act)
        {
            //var commentFlag = string.IsNullOrEmpty(mockMessageTmp.Comment);
            using (var db = new MockMessageEntity())
            {
                //var m =
                //    from info in db.MockMessages
                //    where
                //        //info.RequestType.RequestType.Equals(mockMessageTmp.RequestType.RequestType) &&
                //        //info.RequestType.ServiceType.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId) &&
                //        info.KeyInfo.Equals(mockMessageTmp.KeyInfo)
                //    select
                //        info;

                //var infoTmp = m.Count() > 0 ? m.First() : null;
                //if (m.Count() == 0)
                //{
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
                            //&& info.ServiceType.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId)
                        select info;

                    var rtiTmp = c.Count() > 0 ? c.First() : null;
                    if (null == rtiTmp)
                    {
                        rtiTmp = new RequestTypeInfo
                        {
                            RequestType = mockMessageTmp.RequestType.RequestType
                            //ServiceType = stiTmp
                        };

                        db.RequestTypeInfos.Add(rtiTmp);
                    }

                    rtiTmp.ServiceType = stiTmp;

                    var m =
                    from info in db.MockMessages
                    where
                        //info.RequestType.RequestType.Equals(mockMessageTmp.RequestType.RequestType) &&
                        //info.RequestType.ServiceType.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId) &&
                        info.KeyInfo.Equals(mockMessageTmp.KeyInfo)
                    select
                        info;

                    var infoTmp = m.Count() > 0 ? m.First() : null;

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

                    act(infoTmp);
                    db.MockMessages.Add(infoTmp);

                //}
                //else
                //{                    
                //    act(infoTmp);
                //    //if (!commentFlag)
                //    //{
                //    //    infoTmp.Comment = mockMessageTmp.Comment;
                //    //    infoTmp.LastModifyTime = DateTime.Now;
                //    //}
                //    //if(!string.IsNullOrEmpty(mockMessageTmp.ResponseXml))
                //    //{
                //    //    infoTmp.ResponseXml = mockMessageTmp.ResponseXml;
                //    //    infoTmp.LastModifyTime = DateTime.Now;
                //    //}
                //}

                db.SaveChanges();

                CacheToRedis(infoTmp);

            }
        }

        private static void CacheToRedis(MockMessage mockMessageTmp)
        {

            //ConfigurationOptions config = new ConfigurationOptions
            //{
            //    EndPoints =
            //                    {
            //                        { "10.2.24.151", 6388}
            //                    }
            //};

            //var redis = ConnectionMultiplexer.Connect(config).GetDatabase(10);

            //var cacheValue = new
            //{
            //    request = mockMessageTmp.RequestXml,
            //    response = mockMessageTmp.ResponseXml
            //};
            //var cacheValueStr = JsonConvert.SerializeObject(cacheValue);
            //redis.set

            //var keyTmp = mockMessageTmp.RequestXml.Message2KeyWord();// Message2KeyWord(mockMessageTmp);

            RSHelp.DB.HashSetAsync(mockMessageTmp.KeyInfo, new HashEntry[]{
                new HashEntry("request",mockMessageTmp.RequestXml),
                new HashEntry("response",mockMessageTmp.ResponseXml),
                new HashEntry("timeout",JsonConvert.SerializeObject(mockMessageTmp.Timeout))});
            RSHelp.DB.KeyExpireAsync(mockMessageTmp.KeyInfo, expiry: new TimeSpan(1, 0, 0));
            //redis.StringSetAsync(mockMessageTmp.RequestXml.GetHashCode().ToString(), cacheValueStr, expiry: new TimeSpan(1, 0, 0));
        }        
    }
}
