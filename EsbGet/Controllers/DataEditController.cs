using MockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using EsbGet.EsbUrlController;
using Newtonsoft.Json;
using EsbGet.RabbitHelp;
using HashHelp;
using EsbRabbitHelp;

namespace EsbGet.Controllers
{
    public class DataEditController : ApiController
    {
        [Route("api/GetByRequest")]
        [HttpPost]
        public MockMessage GetByRequest([FromBody]string request)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(request);

            //var res = requestHelp.Request("rpc_getByRequest");

            var requestType = reqXml.GetRequestType();// GetRequestType(reqXml);

            var reqXmlToCompare = reqXml.FormatRequestBody();

            var res = string.Empty;

            //var redis = RSHelp.DB;
            //res = redis.HashGetAsync(reqXmlToCompare, "response").Result.ToString();// .StringGet(reqXmlToCompare.GetHashCode().ToString());
            //res = string.Empty;

            
            var queryTmp = new
            {
                type = requestType,
                request = reqXmlToCompare,
                key = reqXmlToCompare.Message2KeyWord()
            };

            var rpcClient = new RPCClient();

            var callMessage = JsonConvert.SerializeObject(queryTmp);

            //Console.WriteLine(" [x] Requesting fib(30)");
            res = rpcClient.Call(callMessage, PipeName.rpc_getByRequest.ToString());
            //Console.WriteLine(" [.] Got '{0}'", response);

            rpcClient.Close();

            var message = JsonConvert.DeserializeObject<MockMessage>(res);

            message.RequestXml = message.RequestXml.Replace('"','\'');
            message.ResponseXml = message.ResponseXml.Replace('"', '\'');
            return message;
        }

        public List<MockMessage> GetByComment([FromUri]string comment)
        {
            var rpcClient = new RPCClient();

            var res = rpcClient.Call(comment, PipeName.rpc_getByComment.ToString());
            
            rpcClient.Close();

            var messageLst = JsonConvert.DeserializeObject<List<MockMessage>>(res);

            foreach(var message in messageLst)
            {
                message.RequestXml = message.RequestXml.Replace('"', '\'');
                message.ResponseXml = message.ResponseXml.Replace('"', '\'');
            }

            return messageLst;
        }

        public List<MockMessage> Get()
        {
            var rpcClient = new RPCClient();

            var res = rpcClient.Call("give_me_more", PipeName.rpc_get_all.ToString());

            rpcClient.Close();

            var messageLst = JsonConvert.DeserializeObject<List<MockMessage>>(res);

            foreach (var message in messageLst)
            {
                message.RequestXml = message.RequestXml.Replace('"', '\'');
                message.ResponseXml = message.ResponseXml.Replace('"', '\'');
            }

            return messageLst;
        }

        [HttpPost]
        public void Post(MockMessage Data)
        {
            //var requestHelp = new PullRequestHelp
            //{
            //    WsName = Data.RequestType.ServiceType.WSName,
            //    WebServiceId = Data.RequestType.ServiceType.WebServiceId,
            //    RealUrl = realUrl,
            //    RequestXml = requestXML
            //};

            //requestHelp.UpdateOrAddMockMessage(.RequestHelp();
            Data.KeyInfo = Data.RequestXml.Message2KeyWord();
            var callmessage = JsonConvert.SerializeObject(Data);

            var messageClient = new MessageClient();

            messageClient.Send(callmessage, PipeName.EsbNewData.ToString());

            //var rpcClient = new RPCClient();

            //var res = rpcClient.Call(callmessage, "EsbMockData");

            //rpcClient.Close();

            ////var message = JsonConvert.DeserializeObject<bool>(res);
        }


        public void Put(SampleMessage data)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(data.RequestXml);

            var requestForComp = reqXml.FormatRequestBody();
            var timeout = string.IsNullOrEmpty(data.TimeOut) ? TimeSpan.MinValue : JsonConvert.DeserializeObject<TimeSpan>("'" + data.TimeOut + "'");
            var infoTmp = new MockMessage
            {
                RequestXml = requestForComp,
                KeyInfo = requestForComp.Message2KeyWord(),
                ResponseXml = data.ResponseXml,
                RequestType = new RequestTypeInfo
                {
                    RequestType = reqXml.GetRequestType(),
                    ServiceType = new ServiceTypeInfo
                    {
                        WebServiceId = data.WebServiceId
                    }
                },
                Comment = data.Comment,
                Timeout = timeout
            };

            var callmessage = JsonConvert.SerializeObject(infoTmp);

            var messageClient = new MessageClient();

            messageClient.Send(callmessage, PipeName.EsbEditData.ToString());


            //var rpcClient = new RPCClient();

            //var res = rpcClient.Call(callmessage, "EsbMockData");

            //rpcClient.Close();
        }

        //public void Put(PutMessageWithRes data)
        //{
        //    XmlDocument reqXml = new XmlDocument();
        //    reqXml.LoadXml(data.RequestXml);

        //   var infoTmp = new MockMessage
        //    {
        //        RequestXml = reqXml.FormatRequestBody(),
        //        ResponseXml = data.ResponseXml,
        //        RequestType = new RequestTypeInfo
        //        {
        //            RequestType = reqXml.GetRequestType(),
        //            ServiceType = new ServiceTypeInfo
        //            {
        //                WebServiceId = data.WebServiceId
        //            }
        //        }
        //    };

        //   var callmessage = JsonConvert.SerializeObject(infoTmp);

        //   var messageClient = new MessageClient();

        //   messageClient.Send(callmessage, "EsbMockData");

            
        //    //var rpcClient = new RPCClient();

        //    //var res = rpcClient.Call(callmessage, "EsbMockData");

        //    //rpcClient.Close();
        //}

        //[Route("api/PutWithComment")]
        //[HttpPost]
        //public void Put(PutMessageWithComment data)
        //{
        //    XmlDocument reqXml = new XmlDocument();
        //    reqXml.LoadXml(data.RequestXml);

        //    var infoTmp = new MockMessage
        //    {
        //        RequestXml = reqXml.FormatRequestBody(),
        //        RequestType = new RequestTypeInfo
        //        {
        //            RequestType = reqXml.GetRequestType(),
        //            ServiceType = new ServiceTypeInfo
        //            {
        //                WebServiceId = data.WebServiceId
        //            }
        //        },
        //        Comment = data.Comment
        //    };

        //    var callmessage = JsonConvert.SerializeObject(infoTmp);

        //    var messageClient = new MessageClient();

        //    messageClient.Send(callmessage, "EsbMockData");


        //    //var rpcClient = new RPCClient();

        //    //var res = rpcClient.Call(callmessage, "EsbMockData");

        //    //rpcClient.Close();
        //}

        //[Route("api/PutWithTimeOut")]
        //[HttpPost]
        //public void Put(MessageWithTimeOut data)
        //{
        //    XmlDocument reqXml = new XmlDocument();
        //    reqXml.LoadXml(data.RequestXml);

        //    var infoTmp = new MockMessage
        //    {
        //        RequestXml = reqXml.FormatRequestBody(),
        //        RequestType = new RequestTypeInfo
        //        {
        //            RequestType = reqXml.GetRequestType(),
        //            ServiceType = new ServiceTypeInfo
        //            {
        //                WebServiceId = data.WebServiceId
        //            }
        //        },
        //        Timeout = data.Timeout
        //    };

        //    var callmessage = JsonConvert.SerializeObject(infoTmp);

        //    var messageClient = new MessageClient();

        //    messageClient.Send(callmessage, "EsbMockData");


        //    //var rpcClient = new RPCClient();

        //    //var res = rpcClient.Call(callmessage, "EsbMockData");

        //    //rpcClient.Close();
        //}

        public void Delete([FromBody]string request)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(request);

            var requestType = reqXml.GetRequestType();// GetRequestType(reqXml);

            var reqXmlToCompare = reqXml.FormatRequestBody();

            var queryTmp = new
            {
                type = requestType,
                request = reqXmlToCompare,
                key = reqXmlToCompare.Message2KeyWord()
            };

            var callmessage = JsonConvert.SerializeObject(queryTmp);

            var messageClient = new MessageClient();// messageClient();
            //var rpcClient = new RPCClient();

            messageClient.Send(callmessage, PipeName.rpc_delete.ToString());
        }
    }
}
