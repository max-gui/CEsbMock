using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml;
using EsbGet.EsbUrlController;
using MockEntity;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using EsbGet.RabbitHelp;
using HashHelp;
using System.Threading;
using EsbRedisHelp;
using EsbRabbitHelp;

namespace EsbGet
{
    public class PullRequestHelp
    {
        public string RequestXml { get; set; }

        public string RequestXmlForCompare { get; set; }

        public string ResponseXml { get; set; }

        public RequestTypeInfo RequestType { get; set; }

        public string RequestHelp()
        {
            var ret = string.Empty;

            var xmlTmpIn = new XmlDocument();
            xmlTmpIn.LoadXml(this.RequestXml);

            var typeForQ = xmlTmpIn.GetRequestType();
            RequestXmlForCompare = xmlTmpIn.FormatRequestBody();

            #region tmp
            var m = RedisHelp.DB.HashGetAsync("timeoutTmp", typeForQ.ToLower()).Result.ToString();
            //var m = new EsbRedisHelp.RedisHelp().DB.StringGet(typeForQ.ToLower() + ".t").ToString();
            var timeTmp = string.IsNullOrEmpty(m) ? "00:00:00" : m;

            var timeout = TimeSpan.Parse(timeTmp);
            if (!timeout.Equals(default(TimeSpan)))
            {
                Thread.Sleep(timeout);
                return ret;
            }
            #endregion

            var rpcClient = new RPCClient();

            var typeMessage = rpcClient.Call(typeForQ, PipeName.EsbRequestInfoOut.ToString());

            rpcClient.Close();

            var typeTmp = JsonConvert.DeserializeObject<RequestTypeInfo>(typeMessage);

            this.RequestType = typeTmp;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                var requestXMLForPost = this.RequestXml;
                requestXMLForPost = requestXMLForPost.Replace("&", "&amp;");
                requestXMLForPost = requestXMLForPost.Replace("<", "&lt;");
                requestXMLForPost = requestXMLForPost.Replace(">", "&gt;");
                var content = @"<?xml version='1.0' encoding='utf-8'?><soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><soap:Body><Request xmlns='http://tempuri.org/'><requestXML>" +
                    requestXMLForPost +
                "</requestXML></Request></soap:Body></soap:Envelope>";

                var contentTmp = new StringContent(content, System.Text.Encoding.UTF8, "text/xml");

                var response = client.PostAsync(this.RequestType.ServiceType.WsUrl, contentTmp).Result;

                if (response.IsSuccessStatusCode)
                {
                    ret = response.Content.ReadAsStringAsync().Result;
                    var xmlTmp = new XmlDocument();
                    xmlTmp.LoadXml(ret);
                    ret = xmlTmp.InnerText;

                    this.ResponseXml = ret;

                    if (EsbFlag.GetFlag.Equals(GlobalFlag.GetBack))
                    {
                        UpdateOrAddMockMessage();
                    }
                }
            }
            return ret;
        }

        public void UpdateOrAddMockMessage(string comment = default(string))
        {

            var infoTmp = new MockMessage
            {
                InTime = DateTime.Now,
                RequestXml = this.RequestXmlForCompare,
                KeyInfo = this.RequestXmlForCompare.Message2KeyWord(),
                ResponseXml = this.ResponseXml,
                RequestType = this.RequestType,
                LastModifyTime = DateTime.MaxValue,
                Comment = comment
            };

            string message = JsonConvert.SerializeObject(infoTmp);

            var client = new MessageClient();
            client.Send(message, PipeName.EsbUpdateOrAddMockData.ToString());
        }
    }
}