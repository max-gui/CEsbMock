using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using EsbGet.EsbUrlController;
using EsbGet.RabbitHelp;
using Newtonsoft.Json;
using MockEntity;
using System.Threading;
using Newtonsoft.Json.Linq;
using EsbRedisHelp;
using HashHelp;

namespace EsbGet
{
    public class GetRequestHelp
    {
        public string RequestXML { get; set; }

        //private static RedisHelp RSHelp = new RedisHelp();
        public string Request(string pipeName)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(this.RequestXML);

            var requestType = reqXml.GetRequestType();// GetRequestType(reqXml);

            var reqXmlToCompare = reqXml.FormatRequestBody();

            var res = string.Empty;

            //var redis = RSHelp.DB;
            var keyTmp = reqXmlToCompare.Message2KeyWord();
            //res = redis.HashGetAsync(keyTmp, "response").Result.ToString();// .StringGet(reqXmlToCompare.GetHashCode().ToString());
            //var timeout = default(TimeSpan);
            //var timeTmp = redis.HashGetAsync(keyTmp, "timeout").Result.ToString();
            //res = string.Empty;

            //if (string.IsNullOrEmpty(res))
            //{
            var queryTmp = new
            {
                type = requestType,
                request = reqXmlToCompare,
                key = keyTmp
            };

            var rpcClient = new RPCClient();

            var callMessage = JsonConvert.SerializeObject(queryTmp);

            //Console.WriteLine(" [x] Requesting fib(30)");
            res = rpcClient.Call(callMessage, pipeName);

            rpcClient.Close();

            var defaultMessage = JsonConvert.SerializeObject(
                new
            {
                ResponseXml = string.Empty,
                Timeout = default(TimeSpan)
            });
            var message = string.IsNullOrEmpty(res) ?
                JObject.Parse(defaultMessage) :
                JObject.Parse(res);
            res = message["ResponseXml"].ToString();//"http://ws.bill.payment.fws.qa.nt.ctripcorp.com/payment-base-merchantservice/merchantservice.asmx";
            var timeTmp = message["Timeout"].ToString();

            #region tmp
            var m = RedisHelp.DB.HashGetAsync("timeoutTmp", requestType.ToLower()).Result.ToString();
            //var m = new EsbRedisHelp.RedisHelp().DB.StringGet(requestType.ToLower() + ".t").ToString();
            timeTmp = string.IsNullOrEmpty(m) ? timeTmp : m;
            #endregion
            //JsonConvert.DeserializeObject<MessageWithTimeOut>(res);
            //if (!string.IsNullOrEmpty(res))
            //{
            //    var message = JsonConvert.DeserializeObject<MessageWithTimeOut>(res);

            //    res = message.RequestXml;

            //    timeout = message.Timeout;
            //}
            //Console.WriteLine(" [.] Got '{0}'", response);


            //}
            //else
            //{
            var timeout = TimeSpan.Parse(timeTmp);
            //}

            Thread.Sleep(timeout);

            return res;
        }


    }
}