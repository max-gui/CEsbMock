using ControllerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EsbGet.EsbUrlController.Auto
{
    /// <summary>
    /// Summary description for Ctrip_SOA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Ctrip_SOA : System.Web.Services.WebService
    {
        [WebMethod]
        public string Request(string requestXML)
        {
            var res = string.Empty;
            if (EsbFlag.GetFlag.Equals(GlobalFlag.GetBack))
            {
                var get = new Get.Ctrip_SOA_ESB();//.GetHelp();
                res = get.Request(requestXML);
            }

            if (string.IsNullOrEmpty(res))
            {
                var pull = new Pull.Ctrip_SOA_ESB(); //.PullHelp();
                res = pull.Request(requestXML);
            }

            return res;
        }
    }
}
