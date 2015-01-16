using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;
using EsbRedisHelp;
using HashHelp;
using ControllerLib;

namespace ControllerLib
{
    public class GetRequestHelp
    {
        public string RequestXML { get; set; }

        public string Request(string pipeName)
        {
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(this.RequestXML);

            var requestType = reqXml.GetRequestType();

            var reqXmlToCompare = reqXml.FormatRequestBody();

            var res = string.Empty;

            var keyTmp = reqXmlToCompare.Message2KeyWord();

            //var queryTmp = new
            //{
            //    type = requestType,
            //    request = reqXmlToCompare,
            //    key = keyTmp
            //};

            var rpcClient = new RPCClient();

            var callMessage = keyTmp;

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
            res = message["ResponseXml"].ToString();
            var timeTmp = message["Timeout"].ToString();

            #region tmp
            var m = RedisHelp.DB.HashGetAsync("timeoutTmp", requestType.ToLower()).Result.ToString();
            //var m = new EsbRedisHelp.RedisHelp().DB.StringGet(requestType.ToLower() + ".t").ToString();
            timeTmp = string.IsNullOrEmpty(m) ? timeTmp : m;
            #endregion
            var timeout = TimeSpan.Parse(timeTmp);

            Thread.Sleep(timeout);

            return res;
        }


    }
}