using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsbGet.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataRabbit;
using EsbRabbitHelp;
using MockEntity;
using System.Threading;
using ControllerLib;

namespace EsbGet.Controllers.Tests
{
    [TestClass()]
    public class EsbUrlControllerTests
    {
        private static Task ta = default(Task);
        [AssemblyInitialize]
        public static void Init(TestContext tc)
        {
            ta = new TaskFactory().StartNew(() =>
                {
                    Program.Main(new string[] { });
                });
        
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            Program.cts.Cancel();
            ta.Wait();
        }

        [TestMethod()]
        public void AutoTest()
        {
            var test = new EsbUrlController();
            
            test.Request = new System.Net.Http.HttpRequestMessage(new System.Net.Http.HttpMethod("Get"),
                "http://soa.fws.qa.nt.ctripcorp.com/SOA.ESB/lookup.ashx?UserID=410471&RequestType=payment.tmpay.service.selectcustomerticketcollection&Environment=fws&timestamp=&AppID=410471");
            var res = test.Auto();

            var jsonTmp = JsonConvert.SerializeObject(res);
            var joTmp = JObject.Parse(jsonTmp);

            var wsName = joTmp["WSName"].ToString();
            var webServiceId = joTmp["WebServiceID"].ToString();
            var wsUrl = joTmp["WSUrl"].ToString();

            Assert.AreEqual("http://10.2.8.70:8059/EsbGet/EsbUrlController/Auto/Ctrip.SOA.ESB.asmx", wsUrl);
            Assert.AreEqual("410301", webServiceId);
            Assert.AreEqual("Payment.TMPay.Service", wsName);

            var rpcClient = new RPCClient();

            var typeForQ = "Payment.TMPay.Service.SelectCustomerTicketCollection".ToLower();
            var typeMessage = rpcClient.Call(typeForQ, PipeName.EsbRequestInfoOut.ToString());

            rpcClient.Close();

            var typeTmp = JsonConvert.DeserializeObject<RequestTypeInfo>(typeMessage);

            Assert.AreEqual(typeForQ, typeTmp.RequestType);
            Assert.AreEqual(webServiceId, typeTmp.ServiceType.WebServiceId);
            Assert.AreEqual(wsName, typeTmp.ServiceType.WSName);
            Assert.AreEqual("http://cardint.fws.qa.nt.ctripcorp.com/payment-tmpay-service/paymentservice.asmx", typeTmp.ServiceType.WsUrl);
        }
    }
}
