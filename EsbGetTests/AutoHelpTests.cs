using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsbGet.EsbUrlController.Auto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Xml;
using System.Threading;
using EsbGet.EsbUrlController.Get;
using ControllerLib;

namespace EsbGet.EsbUrlController.Auto.Tests
{
    [TestClass()]
    public class AutoHelpTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            var testXml = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='410471' RequestType='Payment.TMPay.Service.SelectCustomerTicketCollection' Culture='cn' RequestID='e199b1f2-0c11-4a30-b4f9-69af2bb602d9' ClientIP='172.16.150.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fat18' UseMemoryQ='false' />
        <SelectCustomerTicketCollectionRequest>
        <CustomerID>13641391782</CustomerID>
        </SelectCustomerTicketCollectionRequest>
        </Request>";
            var test = new Ctrip_SOA();// AutoHelp();
            EsbFlag.GetFlag = GlobalFlag.GetBack;
            var res = test.Request(testXml);

            var testResXml = @"<?xml version='1.0'?>
<Response>
  <Header ServerIP='10.2.6.47' ShouldRecordPerformanceTime='false' ResultCode='Success' ResultNo='0' ResultMsg='成功' RequestBodySize='0' SerializeMode='Xml' RouteStep='0' />
  <SelectCustomerTicketCollectionResponse>
    <TicketCollectionItemList>
      <TicketCollectionItem>
        <TicketCategoryID>3</TicketCategoryID>
        <TicketCategoryName>任我行</TicketCategoryName>
        <Description>携程任我行游票</Description>
        <TotalAmount>292.00</TotalAmount>
        <WillExpireAmount>0.00</WillExpireAmount>
      </TicketCollectionItem>
    </TicketCollectionItemList>
  </SelectCustomerTicketCollectionResponse>
</Response>";

            var testXmlRes = new XmlDocument();
            testXmlRes.LoadXml(testResXml);
            var resToVerify = testXmlRes.InnerXml;//.ToString();
            testXmlRes.LoadXml(res);
            res = testXmlRes.InnerXml;
            Assert.AreEqual(resToVerify,res);

            EsbFlag.GetFlag = GlobalFlag.GetThrough;
            res = test.Request(testXml);
            
            testXmlRes.LoadXml(res);
            res = testXmlRes.InnerXml;
            Assert.IsTrue(!string.IsNullOrEmpty(res));//.AreEqual(resToVerify, res);

            //res = string.Empty;
            //while (string.IsNullOrEmpty(res))
            //{
            //    var backTmp = new GetHelp();
            //    res = backTmp.Request(testXml);
            //}

            //testXmlRes.LoadXml(res);
            //res = testXmlRes.InnerXml;
            
            //Assert.AreEqual(resToVerify, res);
            //Thread.Sleep(new TimeSpan(1,0,0));
        }
    }
}
