using EsbRedisHelp;
using MockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;
using EsbGet.EsbUrlController;

namespace EsbGet.EsbUrlController.Pull
{
    /// <summary>
    /// Summary description for PullHelp
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PullHelp : System.Web.Services.WebService
    {
        //private static RedisHelp RSHelp = new RedisHelp();

        [WebMethod]
        public string Request(string requestXML)
        {

            //var tag = this.Context.Request.QueryString["tag"];
            
            //var redis = RSHelp.DB;
            //var tagValue = redis.StringGet(tag);//.StringSet(tag, realUrl, expiry: new TimeSpan(0, 10, 0));// subscribeSelfFilter(redis, subItem, waitTime, (e) => true);
            //redis.StringSet(tag, tagValue, expiry: new TimeSpan(0, 0, 1));

            //var a = JObject.Parse(tagValue);
            //var realUrl = a["WSUrl"].ToString();//"http://ws.bill.payment.fws.qa.nt.ctripcorp.com/payment-base-merchantservice/merchantservice.asmx";
            //var wsName = a["WSName"].ToString();
            //var webServiceId = a["WebServiceId"].ToString();
            //var ret = string.Empty;

            //var xmlTmp = new XmlDocument();
            //xmlTmp.LoadXml(requestXML);

            //var tmp = xmlTmp.GetRequestType();

            ////get reqtype
            //var typeTmp = JsonConvert.DeserializeObject<RequestTypeInfo>("");

            var requestHelp = new PullRequestHelp
            {
                //WsName = typeTmp.ServiceType.WSName,
                //WebServiceId = typeTmp.ServiceType.WebServiceId,
                //RealUrl = typeTmp.ServiceType.WsUrl,
                RequestXml = requestXML//,
                //RequestType = typeTmp
            };

            return requestHelp.RequestHelp();

            //return PullRequestHelp(requestXML, realUrl, wsName, webServiceId, ref ret);
        }
    }
}
