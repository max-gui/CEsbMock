using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsbGet.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using HashHelp;
using EsbGet.EsbUrlController;
using MockEntity;
using ControllerLib;

namespace EsbGet.Controllers.Tests
{
    [TestClass()]
    public class DataEditControllerTests
    {
        static string testXml = string.Empty;
        static string resToVerify = string.Empty;
        static string postXml = string.Empty;
        static string postToVerify = string.Empty;

        [ClassInitialize]
        public static void Init(TestContext tc)
        {
            testXml = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='410471' RequestType='Payment.TMPay.Service.SelectCustomerTicketCollection' Culture='cn' RequestID='e199b1f2-0c11-4a30-b4f9-69af2bb602d9' ClientIP='172.16.150.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fat18' UseMemoryQ='false' />
        <SelectCustomerTicketCollectionRequest>
        <CustomerID>13641391782</CustomerID>
        </SelectCustomerTicketCollectionRequest>
        </Request>";

            postXml = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='410471' RequestType='Payment.TMPay.Service.SelectCustomerTicketCollection' Culture='cn' RequestID='e199b1f2-0c11-4a30-b4f9-69af2bb602d9' ClientIP='172.16.150.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fat18' UseMemoryQ='false' />
        <SelectCustomerTicketCollectionRequest>
        <CustomerID>testId</CustomerID>
        </SelectCustomerTicketCollectionRequest>
        </Request>"; ;

            var testXmlRes = new XmlDocument();
            testXmlRes.LoadXml(testXml);
            resToVerify = testXmlRes.FormatRequestBody().Message2KeyWord();//.ToString();

            testXmlRes.LoadXml(postXml);
            postToVerify = testXmlRes.FormatRequestBody().Message2KeyWord();


        }

        [TestMethod()]
        public void Request2KeyTest()
        {
            var test = new DataEditController();
            var res = test.Request2Key(testXml);
            Assert.AreEqual(resToVerify, res);
        }

        [TestMethod()]
        public void GetByKeyTest()
        {
            var test = new DataEditController();
            var messageTmp = test.GetByKey(resToVerify);

            Assert.IsInstanceOfType(messageTmp, typeof(MockMessage));
            var resTmp = messageTmp.RequestXml.Replace('\'', '"');
            var keyTmp = resTmp.Message2KeyWord();
            Assert.AreEqual(resToVerify, keyTmp);
        }

        [TestMethod()]
        public void GetByCommentTest()
        {
            var comment = "410301";
            var test = new DataEditController();
            var messageTmp = test.GetByComment(comment);

            Assert.IsInstanceOfType(messageTmp, typeof(List<MockMessage>));

            foreach (var mtp in messageTmp)
            {
                Assert.AreEqual(comment, mtp.Comment);
            }
        }

        [TestMethod()]
        public void GetTest()
        {
            var test = new DataEditController();
            var messageTmp = test.Get();

            if (null == messageTmp)
            {
                return;
            }

            Assert.IsInstanceOfType(messageTmp, typeof(List<MockMessage>));

            foreach (var mtp in messageTmp)
            {
                Assert.IsInstanceOfType(mtp, typeof(MockMessage));
            }
        }

        [TestMethod()]
        public void PostTest()
        {
            var test = new DataEditController();

            test.Delete(postToVerify);

            var resKey = AddHelp(test);
            Assert.AreEqual(postToVerify, resKey);
        }

        private static string AddHelp(DataEditController test)
        {
            var comTmp = "postTmp";
            var resTmp = "resTmp";
            var toTmp = "00:10:00";
            var postTmp = new PostMessage
            {
                Comment = comTmp,
                RequestXml = postXml,
                ResponseXml = resTmp,
                TimeOut = toTmp
            };

            var resKey = test.Post(postTmp);
            return resKey;
        }

        [TestMethod()]
        public void PutTest()
        {
            var tsTmp = "00:00:10";
            var comTest = "comTest";
            var resTest = "resTest";
            var test = new DataEditController();
            var editTmp = new PutMessage
            {
                Comment = comTest,
                KeyInfo = resToVerify,
                TimeOut = tsTmp,
                ResponseXml = resTest
            };

            var orTmp = test.GetByKey(resToVerify);
            Assert.IsNotNull(orTmp);

            var messageTmp = test.Put(editTmp);
            Assert.AreEqual(resToVerify, messageTmp);

            var resTmp = test.GetByKey(resToVerify);
            Assert.IsNotNull(resTmp);
            Assert.AreEqual(comTest, resTmp.Comment);
            Assert.AreEqual(resToVerify, resTmp.KeyInfo);
            Assert.AreEqual(tsTmp, resTmp.Timeout.ToString());
            Assert.AreEqual(resTest, resTmp.ResponseXml);

            editTmp.Comment = orTmp.Comment;
            editTmp.KeyInfo = orTmp.KeyInfo;
            editTmp.TimeOut = orTmp.Timeout.ToString();
            editTmp.ResponseXml = orTmp.ResponseXml;
            messageTmp = test.Put(editTmp);
            Assert.AreEqual(resToVerify, messageTmp);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var test = new DataEditController();
            AddHelp(test);

            var delTmp = test.GetByKey(postToVerify);
            Assert.IsNotNull(delTmp);
            Assert.AreEqual(postToVerify, delTmp.KeyInfo);

            var flag = test.Delete(postToVerify);
            Assert.AreEqual(true, flag);

            delTmp = test.GetByKey(postToVerify);
            Assert.IsNull(delTmp);
        }
    }
}
