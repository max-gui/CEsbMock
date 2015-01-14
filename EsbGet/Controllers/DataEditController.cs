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
using Newtonsoft.Json.Linq;

namespace EsbGet.Controllers
{
    public class DataEditController : ApiController
    {
        [Route("api/request2Key")]
        [HttpPost]
        public string Request2Key([FromBody]string request)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(request);

            var requestType = reqXml.GetRequestType();

            var reqXmlToCompare = reqXml.FormatRequestBody();

            var key = reqXmlToCompare.Message2KeyWord();

            return key;
        }

        public MockMessage GetByKey(string key)
        {
            var res = string.Empty;

            var rpcClient = new RPCClient();

            //var callMessage = JsonConvert.SerializeObject(key);
            var callMessage = key;
            res = rpcClient.Call(callMessage, PipeName.rpc_getByKey.ToString());

            rpcClient.Close();

            var message = default(MockMessage);
            if (!string.IsNullOrEmpty(res))
            {
                message = JsonConvert.DeserializeObject<MockMessage>(res);
                message.RequestXml = message.RequestXml.Replace('"', '\'');
                message.ResponseXml = message.ResponseXml.Replace('"', '\'');
            }
            //return Request.CreateResponse<MockMessage>(HttpStatusCode.OK, message);
            return message;
        }

        public List<MockMessage> GetByComment([FromUri]string comment)
        {
            var rpcClient = new RPCClient();

            var res = rpcClient.Call(comment, PipeName.rpc_getByComment.ToString());

            rpcClient.Close();

            var messageLst = JsonConvert.DeserializeObject<List<MockMessage>>(res);

            foreach (var message in messageLst)
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

            if(string.IsNullOrEmpty(res))
            {
                return null;
            }
            var messageLst = JsonConvert.DeserializeObject<List<MockMessage>>(res);

            foreach (var message in messageLst)
            {
                message.RequestXml = message.RequestXml.Replace('"', '\'');
                message.ResponseXml = message.ResponseXml.Replace('"', '\'');
            }

            return messageLst;
        }

        [HttpPost]
        public string Post(PostMessage Data)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(Data.RequestXml);

            var requestType = reqXml.GetRequestType().ToLower();

            var reqXmlToCompare = reqXml.FormatRequestBody();

            var key = reqXmlToCompare.Message2KeyWord();

            var help = new EsbUrlController();

            help.Request = new System.Net.Http.HttpRequestMessage(new System.Net.Http.HttpMethod("Get"),
                string.Format(
                "http://soa.fws.qa.nt.ctripcorp.com/SOA.ESB/lookup.ashx?UserID=410471&RequestType={0}&Environment=fws&timestamp=&AppID=410471", 
                requestType));

            var ret = help.Auto();

            var jsonTmp = JsonConvert.SerializeObject(ret);
            var joTmp = JObject.Parse(jsonTmp);

            var wsName = joTmp["WSName"].ToString();
            var webServiceId = joTmp["WebServiceID"].ToString();
            var wsUrl = joTmp["WSUrl"].ToString();

            var timeout = string.IsNullOrEmpty(Data.TimeOut) ? TimeSpan.MinValue : JsonConvert.DeserializeObject<TimeSpan>("'" + Data.TimeOut + "'");
            
            var mockMessage = new MockMessage
            {
                Comment = Data.Comment,
                KeyInfo = key,
                RequestType = new RequestTypeInfo { 
                    RequestType = requestType,
                    ServiceType = new ServiceTypeInfo
                    {
                        WebServiceId = webServiceId,
                        WSName = wsName,
                        WsUrl = wsUrl
                    }
                },
                RequestXml = reqXmlToCompare,
                ResponseXml = Data.ResponseXml,
                Timeout = timeout
            };

            var callmessage = JsonConvert.SerializeObject(mockMessage);

            var rpc = new RPCClient();
            var res = rpc.Call(callmessage, PipeName.EsbNewData.ToString());

            return res;
            //var messageClient = new MessageClient();

            //messageClient.Send(callmessage, PipeName.EsbNewData.ToString());
        }


        public string Put(PutMessage data)
        {
            var timeout = string.IsNullOrEmpty(data.TimeOut) ? TimeSpan.MinValue : JsonConvert.DeserializeObject<TimeSpan>("'" + data.TimeOut + "'");
            var infoTmp = new MockMessage
            {
                KeyInfo = data.KeyInfo,
                ResponseXml = data.ResponseXml,
                Comment = data.Comment,
                Timeout = timeout
            };

            var callmessage = JsonConvert.SerializeObject(infoTmp);

            var rpc = new RPCClient();
            var key = rpc.Call(callmessage, PipeName.EsbEditData.ToString());

            return key;
            //var messageClient = new MessageClient();

            //messageClient.Send(callmessage, PipeName.EsbEditData.ToString());
        }

        public bool Delete(string reqKey)
        {
            //XmlDocument reqXml = new XmlDocument();
            //reqXml.LoadXml(request);

            //var requestType = reqXml.GetRequestType();

            //var reqXmlToCompare = reqXml.FormatRequestBody();

            //var queryTmp = new
            //{
            //    type = requestType,
            //    request = reqXmlToCompare,
            //    key = reqXmlToCompare.Message2KeyWord()
            //};

            //var callmessage = JsonConvert.SerializeObject(queryTmp);

            var rpc = new RPCClient();
            var res = rpc.Call(reqKey, PipeName.rpc_delete.ToString());

            var flag = false;
            flag = JsonConvert.DeserializeObject<bool>(res);

            return flag;
            //var messageClient = new MessageClient();

            //messageClient.Send(callmessage, PipeName.rpc_delete.ToString());
        }
    }
}
