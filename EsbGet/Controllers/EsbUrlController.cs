using EsbGet.RabbitHelp;
using EsbRedisHelp;
using MockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EsbGet.Controllers
{
    public class EsbUrlController : ApiController
    {
        //private static RedisHelp RSHelp = new RedisHelp();
        [Route("EsbUrlController/Pull/lookup.ashx")]
        [HttpGet]
        public object Pull()//string UserID, string RequestType, string Environment, string timestamp, string AppID)
        {
            //var esbUrl = "http://soa.fws.qa.nt.ctripcorp.com/soa.esb/lookup.ashx";
            //var getUrl = esbUrl + this.Request.RequestUri.Query;

            return pullHelp("Pull");
        }

        private object pullHelp(string urlPara)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://soa.fws.qa.nt.ctripcorp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ttStr = "&timestamp=";
                var ttIndex = this.Request.RequestUri.Query.IndexOf(ttStr);
                var tailStr = this.Request.RequestUri.Query.Substring(ttIndex + ttStr.Length);
                var queryStr = this.Request.RequestUri.Query.Remove(ttIndex) + tailStr.Substring(tailStr.IndexOf("&"));
                // HTTP GET
                var response = client.GetAsync("soa.esb/lookup.ashx" + queryStr);//this.Request.RequestUri.Query);
                var respResult = response.Result;
                if (respResult.IsSuccessStatusCode)
                {
                    var product = respResult.Content.ReadAsStringAsync().Result;//.ReadAsAsync();

                    var a = JObject.Parse(product);
                    //var guid = Guid.NewGuid();
                    //var tag = guid.ToString() + Environment.TickCount;
                    var realUrl = a["WSUrl"].ToString();
                    var wsName = a["WSName"].ToString();
                    var webServiceId = a["WebServiceID"].ToString();
                    //a["WSUrl"] = "http://10.2.8.70:8059/EsbGet/EsbUrlController/Pull/PullHelp.asmx?tag=" + tag;//"http://windev/CtripEsbAsmx/WebService2.asmx?tag=" + tag;
                    a["WSUrl"] = string.Format("http://10.2.8.70:8059/EsbGet/EsbUrlController/{0}/{0}Help.asmx", urlPara);// +tag;
                    
                    //var tagValue = new
                    //{
                    //    WSUrl = realUrl,
                    //    WSName = wsName,
                    //    WebServiceId = webServiceId,
                    //};

                    var reqTmp = new RequestTypeInfo
                    {
                        RequestType = this.Request.GetQueryNameValuePairs().ToList()[1].Value.ToLower(),
                        ServiceType = new ServiceTypeInfo
                        {
                           WebServiceId = webServiceId,
                           WsUrl = realUrl,
                           WSName = wsName
                        }
                    };

                    var callmessage = JsonConvert.SerializeObject(reqTmp);

                    var messageClient = new MessageClient();

                    messageClient.Send(callmessage, "EsbRequestInfoIn");

                    //string json = JsonConvert.SerializeObject(tagValue);

                    //var redis = RSHelp.DB;
                    //var t = redis.StringSet(tag, json, expiry: new TimeSpan(0, 10, 0));// subscribeSelfFilter(redis, subItem, waitTime, (e) => true);

                    var res = new
                    {
                        ErrorMessage = a["ErrorMessage"],

                        Factor = a["Factor"],

                        IsValid = a["IsValid"],

                        RTClass = a["RTClass"],

                        RequestTypeID = a["RequestTypeID"],

                        SaveFailLog = a["SaveFailLog"],

                        SaveFullLog = a["SaveFullLog"],

                        SaveLog = a["SaveLog"],

                        Timeout = a["Timeout"],

                        Timestamp = a["Timestamp"],

                        WSName = a["WSName"],

                        WSUrl = a["WSUrl"],//"http://localhost/CtripEsbAsmx/WebService1.asmx",//"http://10.2.8.70:8059/Asmx/webservice1.asmx",

                        WebServiceID = a["WebServiceID"]

                    };

                    return res;
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }



            //var data = "";
            //data.WSUrl = this + ?op=uuid;

            //return data;
            return null;
        }

        [Route("EsbUrlController/Get/lookup.ashx")]
        [HttpGet]
        public object Get()
        {
            object obj = null;
            var res = new
            {
                ErrorMessage = obj,

                Factor = 0,

                IsValid = true,

                RTClass = 0,

                RequestTypeID = 41041901,

                SaveFailLog = false,

                SaveFullLog = false,

                SaveLog = false,

                Timeout = 60,

                Timestamp = "2014-12-11 19:31:08",

                WSName = "Payment.Base.MerchantService",

                WSUrl = "http://10.2.8.70:8059/EsbGet/EsbUrlController/Get/GetHelp.asmx",//"http://localhost/CtripEsbAsmx/WebService1.asmx",//"http://10.2.8.70:8059/Asmx/webservice1.asmx",

                WebServiceID = 410419

            };

            return res;
        }

        [Route("EsbUrlController/Auto/lookup.ashx")]
        [HttpGet]
        public object Auto()//string UserID, string RequestType, string Environment, string timestamp, string AppID)
        {
            return pullHelp("Auto");
        }
    }
}