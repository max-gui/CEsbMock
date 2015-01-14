using MockEntity;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Xml;

namespace EsbGet.EsbUrlController.Pull
{
    /// <summary>
    /// Summary description for Ctrip_SOA_ESB
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Ctrip_SOA_ESB : System.Web.Services.WebService
    {
        //private static RedisHelp RSHelp = new RedisHelp();

        [WebMethod]
        [Route("EsbUrlController/Pull/Ctrip.SOA.ESB.asmx")]
        public string Request(string requestXML)
        {
            var requestHelp = new PullRequestHelp
            {
                RequestXml = requestXML
            };

            return requestHelp.RequestHelp();
        }
    }
}
