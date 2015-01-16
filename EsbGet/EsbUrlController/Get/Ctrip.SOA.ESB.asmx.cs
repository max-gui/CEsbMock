using ControllerLib;
using EsbRabbitHelp;
using MockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace EsbGet.EsbUrlController.Get
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

        [WebMethod]
        public string Request(string requestXML)
        {
            var requestHelp = new GetRequestHelp
            {
                RequestXML = requestXML
            };

            return requestHelp.Request(PipeName.EsbGetMockData.ToString());
        }
    }
}
