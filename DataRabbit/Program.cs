using EsbMockEntity;
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

namespace DataRabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            
            var rpcTask = new TaskFactory().StartNew(() =>
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("rpc_rabbitData", false, false, false, null);
                        channel.BasicQos(0, 1, false);
                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("rpc_rabbitData", false, consumer);
                        Console.WriteLine(" [x] Awaiting RPC requests");

                        
                        while (true)
                        {
                            var ea =
                                (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                            var body = ea.Body;
                            var props = ea.BasicProperties;
                            var replyProps = channel.CreateBasicProperties();
                            replyProps.CorrelationId = props.CorrelationId;

                            var repTask = Task.Factory.StartNew(() =>
                            {
                                string res = string.Empty;
                            
                                try
                                {
                                    var message = Encoding.UTF8.GetString(body);
                                                                        
                                    var mockMessageTmp = JObject.Parse(message);// JsonConvert.DeserializeObject<MockMessage>(message);

                                    var requestTypeTmp = mockMessageTmp["type"].ToString();
                                    var requestXMLTmp = mockMessageTmp["request"].ToString();

                                    using (var db = new MockMessageEntity())
                                    {
                                        var m =
                                            from info in db.MockMessages
                                            where
                                                info.RequestType.RequestType.Equals(requestTypeTmp) &&
                                                info.RequestXml.Equals(requestXMLTmp)
                                            select
                                                info;

                                        if (m.Count() > 0)
                                        {
                                            res = m.First().ResponseXml;
                                        }
                                    }
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
                            });
                        }
                    }
                } 
            });

            var queWorkerTask = new TaskFactory().StartNew(() =>
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("EsbMockData", false, false, false, null);

                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("EsbMockData", true, consumer);

                        Console.WriteLine(" [*] Waiting for messages." +
                                                 "To exit press CTRL+C");
                        while (true)
                        {
                            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);

                            var mockMessageTmp = JsonConvert.DeserializeObject<MockMessage>(message);

                            Save(mockMessageTmp);

                            Console.WriteLine(" [x] Received {0}", message);
                        }
                    }
                }
            });

            Console.ReadLine();
        }

        private static void Save(MockMessage mockMessageTmp)
        {
            using (var db = new MockMessageEntity())
            {
                var m =
                    from info in db.MockMessages
                    where
                        info.RequestType.RequestType.Equals(mockMessageTmp.RequestType.RequestType) &&
                        info.RequestType.ServiceType.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId) &&
                        info.RequestXml.Equals(mockMessageTmp.RequestXml)
                    select
                        info;

                var infoTmp = m.Count() > 0 ? m.First() : null;
                if (m.Count() == 0)
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
                            && info.ServiceType.WebServiceId.Equals(mockMessageTmp.RequestType.ServiceType.WebServiceId)
                        select info;

                    var rtiTmp = c.Count() > 0 ? c.First() : null;
                    if (null == rtiTmp)
                    {
                        rtiTmp = new RequestTypeInfo
                        {
                            RequestType = mockMessageTmp.RequestType.RequestType,
                            ServiceType = stiTmp
                        };

                        db.RequestTypeInfos.Add(rtiTmp);
                    }

                    infoTmp = new MockMessage
                    {
                        InTime = DateTime.Now,
                        RequestXml = mockMessageTmp.RequestXml,
                        ResponseXml = mockMessageTmp.ResponseXml,
                        RequestType = rtiTmp,
                        LastModifyTime = DateTime.MaxValue
                    };

                    db.MockMessages.Add(infoTmp);

                    db.SaveChanges();

                }

                CacheToRedis(mockMessageTmp);

            }
        }

        private static void CacheToRedis(MockMessage mockMessageTmp)
        {

            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                                {
                                    { "10.2.24.151", 6388}
                                }
            };

            var redis = ConnectionMultiplexer.Connect(config).GetDatabase(10);

            //var cacheValue = new
            //{
            //    request = mockMessageTmp.RequestXml,
            //    response = mockMessageTmp.ResponseXml
            //};
            //var cacheValueStr = JsonConvert.SerializeObject(cacheValue);
            //redis.set
            redis.HashSetAsync(mockMessageTmp.RequestXml, new HashEntry[]{
                new HashEntry("request",mockMessageTmp.RequestXml),
                new HashEntry("response",mockMessageTmp.ResponseXml)});
            redis.KeyExpireAsync(mockMessageTmp.ResponseXml, expiry: new TimeSpan(1, 0, 0));
            //redis.StringSetAsync(mockMessageTmp.RequestXml.GetHashCode().ToString(), cacheValueStr, expiry: new TimeSpan(1, 0, 0));
        }
    }
}
