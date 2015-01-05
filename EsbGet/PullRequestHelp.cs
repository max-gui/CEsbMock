﻿using System;
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

namespace EsbGet
{
    public class PullRequestHelp
    {
        public string RealUrl { get; set; }
        public string WsName { get; set; }
        public string WebServiceId { get; set; }

        public string RequestXml { get; set; }

        public string ResponseXml { get; set; }

        public string RequestHelp()
        {
            var ret = string.Empty;
            
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://ws.bill.payment.fws.qa.nt.ctripcorp.com/payment-base-merchantservice/merchantservice.asmx");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                //client.DefaultRequestHeaders.Add("Content-Type", "text/xml");


                var requestXMLForPost = this.RequestXml;
                requestXMLForPost = requestXMLForPost.Replace("&", "&amp;");
                requestXMLForPost = requestXMLForPost.Replace("<", "&lt;");
                requestXMLForPost = requestXMLForPost.Replace(">", "&gt;");
                var content = @"<?xml version='1.0' encoding='utf-8'?><soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><soap:Body><Request xmlns='http://tempuri.org/'><requestXML>" +
                    requestXMLForPost +
                "</requestXML></Request></soap:Body></soap:Envelope>";

                //var xmlTmp = new XmlDocument();
                //xmlTmp.LoadXml(this.RequestXml);

                //var xmlReqTmp = xmlTmp.SelectSingleNode("Request/Header") as XmlElement;
                //var requestType = xmlReqTmp.Attributes["RequestType"].InnerText;

                //var requestType = xmlTmp.GetRequestType();

                //xmlTmp.removeUnNeededTag();
                //var requestXmlToSave = xmlTmp.InnerXml;

                //var requestXmlToSave = xmlTmp.FormatRequestBody();
                // HTTP POST
                //var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                var contentTmp = new StringContent(content, System.Text.Encoding.UTF8, "text/xml");
                //contentTmp.Headers.Add("Content-Type", "text/xml");
                var response = client.PostAsync(this.RealUrl, contentTmp).Result;

                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MockEntity>());

                if (response.IsSuccessStatusCode)
                {
                    //Uri gizmoUrl = response.Headers.Location;
                    ret = response.Content.ReadAsStringAsync().Result;
                    var xmlTmp = new XmlDocument();
                    xmlTmp.LoadXml(ret);
                    //xmlTmp.SelectSingleNode()
                    ret = xmlTmp.InnerText;

                    //xmlTmp.removeUnNeededTag();
                    //var responseXmlToSave = xmlTmp.InnerXml;
                    this.ResponseXml = ret;

                    UpdateOrAddMockMessage();
                }
            }
            //get uuid from query
            //get url from redis
            //post requestXML to url
            //ger return

            //write db

            return ret;
        }

        public void UpdateOrAddMockMessage(string comment = default(string))
        {
            var xmlTmp = new XmlDocument();
            xmlTmp.LoadXml(this.RequestXml);

                var infoTmp = new MockMessage
                {
                    InTime = DateTime.Now,
                    RequestXml = xmlTmp.FormatRequestBody(),
                    ResponseXml = this.ResponseXml,
                    RequestType = new RequestTypeInfo
                    {
                        RequestType = xmlTmp.GetRequestType(),
                        ServiceType = new ServiceTypeInfo
                        {
                            WebServiceId = this.WebServiceId,
                            WSName = this.WsName,
                            WsUrl = this.RealUrl
                        }
                    },
                    LastModifyTime = DateTime.MaxValue,
                    Comment = comment
                };

            string message = JsonConvert.SerializeObject(infoTmp);

            var client = new MessageClient();
            client.Send(message, "EsbMockData");
        }
    }
}