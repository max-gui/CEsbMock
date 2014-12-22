using EsbGet.RabbitRpcHelp;
using EsbMockEntity;
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
    /// Summary description for GetHelp
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetHelp : System.Web.Services.WebService
    {

        [WebMethod]
        public string Request(string requestXML)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MockEntity>());

            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(requestXML);

            var xmlReqTmp = reqXml.SelectSingleNode("Request/Header") as XmlElement;
            var requestType = xmlReqTmp.Attributes["RequestType"].InnerText;

            reqXml.removeUnNeededTag();
            var reqXmlToCompare = reqXml.InnerXml;

            XmlDocument xmlPattern = new XmlDocument();

            var res = string.Empty;
            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                        {
                            { "10.2.24.151", 6388}
                        }
            };

            var redis = ConnectionMultiplexer.Connect(config).GetDatabase(10);
            res = redis.HashGetAsync(reqXmlToCompare, "response").Result.ToString();// .StringGet(reqXmlToCompare.GetHashCode().ToString());
            res = string.Empty;

            if (string.IsNullOrEmpty(res))
            {
                var queryTmp = new
                {
                    type = requestType,
                    request = reqXmlToCompare
                };

                var rpcClient = new RPCClient();

                var callMessage = JsonConvert.SerializeObject(queryTmp);

                //Console.WriteLine(" [x] Requesting fib(30)");
                res = rpcClient.Call(callMessage);
                //Console.WriteLine(" [.] Got '{0}'", response);

                rpcClient.Close();
            
                //using (var db = new MockMessageEntity())
                //{
                //    var m =
                //        from info in db.MockMessages
                //        where
                //            info.RequestType.RequestType.Equals(requestType) &&
                //            info.RequestXml.Equals(requestXML)
                //        select
                //            info;

                //    if (m.Count() > 0)
                //    {
                //        res = m.First().ResponseXml;
                //    }
                //}
            }
            return res;
        }
    }
}
