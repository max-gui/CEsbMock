using EsbMockEntity;
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

        [WebMethod]
        [Route("EsbUrlController/Pull/Ctrip.SOA.ESB.asmx")]
        public string Request(string requestXML)
        {
            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                        {
                            { "10.2.24.151", 6388}
                        }
            };

            var redis = ConnectionMultiplexer.Connect(config).GetDatabase(10);

            var realUrl = "http://soa.fws.qa.nt.ctripcorp.com/SOA.ESB/Ctrip.SOA.ESB.asmx";
            var wsName = "Ctrip.SOA.ESB.asmx";
            
            var ret = string.Empty;
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                
                var requestXMLForPost = requestXML;
                requestXMLForPost = requestXMLForPost.Replace("<", "&lt;");
                requestXMLForPost = requestXMLForPost.Replace(">", "&gt;");
                var content = @"<?xml version='1.0' encoding='utf-8'?><soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><soap:Body><Request xmlns='http://tempuri.org/'><requestXML>" +
                    requestXMLForPost +
                "</requestXML></Request></soap:Body></soap:Envelope>";

                var xmlTmp = new XmlDocument();
                xmlTmp.LoadXml(requestXML);
                var xmlReqTmp = xmlTmp.SelectSingleNode("Request/Header") as XmlElement;
                var requestType = xmlReqTmp.Attributes["RequestType"].InnerText;
                xmlTmp.removeUnNeededTag();
                var requestXmlToSave = xmlTmp.InnerXml;

                // HTTP POST
                //var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                var contentTmp = new StringContent(content, System.Text.Encoding.UTF8, "text/xml");
                //contentTmp.Headers.Add("Content-Type", "text/xml");
                var response = client.PostAsync(realUrl, contentTmp).Result;

                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MockEntity>());

                if (response.IsSuccessStatusCode)
                {
                    //Uri gizmoUrl = response.Headers.Location;
                    ret = response.Content.ReadAsStringAsync().Result;
                    xmlTmp.LoadXml(ret);
                    //xmlTmp.SelectSingleNode()
                    ret = xmlTmp.InnerText;

                    //xmlTmp.removeUnNeededTag();
                    //var responseXmlToSave = xmlTmp.InnerXml;


                    var infoTmp = new MockMessage
                        {
                            InTime = DateTime.Now,
                            RequestXml = requestXmlToSave,
                            ResponseXml = ret,
                            RequestType = new RequestTypeInfo
                            {
                                RequestType = requestType,
                                ServiceType = new ServiceTypeInfo
                                {
                                    WebServiceId = wsName,
                                    WSName = wsName,
                                    WsUrl = realUrl
                                }
                            },
                            LastModifyTime = DateTime.MaxValue
                        };

                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    {
                        using (var channel = connection.CreateModel())
                        {
                            channel.QueueDeclare("EsbMockData", false, false, false, null);

                            string message = JsonConvert.SerializeObject(infoTmp);// "Hello World!";
                            var body = Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish("", "EsbMockData", null, body);
                            //Console.WriteLine(" [x] Sent {0}", message);
                        }
                    }


                    //using (var db = new MockMessageEntity())
                    //{
                    //    var m =
                    //        from info in db.MockMessages
                    //        where
                    //            info.RequestType.RequestType.Equals(requestType) &&
                    //            info.RequestType.ServiceType.WebServiceId.Equals(webServiceId) &&
                    //            info.RequestXml.Equals(requestXmlToSave)
                    //        select
                    //            info;

                    //    var infoTmp = m.Count() > 0 ? m.First() : null;
                    //    if (m.Count() == 0)
                    //    {
                    //        var b =
                    //            from info in db.ServiceTypes
                    //            where info.WebServiceId.Equals(webServiceId)
                    //            select info;

                    //        var stiTmp = b.Count() > 0? b.First(): null;
                    //        if (null == stiTmp)
                    //        {
                    //            stiTmp = new ServiceTypeInfo
                    //            {
                    //                WebServiceId = webServiceId,
                    //                WSName = wsName,
                    //                WsUrl = realUrl
                    //            };

                    //            db.ServiceTypes.Add(stiTmp);
                    //        }

                    //        var c =
                    //            from info in db.RequestTypeInfos
                    //            where info.RequestType.Equals(requestType)
                    //                && info.ServiceType.WebServiceId.Equals(webServiceId)
                    //            select info;

                    //        var rtiTmp = c.Count() > 0 ? c.First() : null;
                    //        if (null == rtiTmp)
                    //        {
                    //            rtiTmp = new RequestTypeInfo
                    //            {
                    //                RequestType = requestType,
                    //                ServiceType = stiTmp
                    //            };

                    //            db.RequestTypeInfos.Add(rtiTmp);
                    //        }

                    //        infoTmp = new MockMessage
                    //        {
                    //            InTime = DateTime.Now,
                    //            RequestXml = requestXmlToSave,
                    //            ResponseXml = ret,
                    //            RequestType = rtiTmp,
                    //            LastModifyTime = DateTime.MaxValue
                    //        };

                    //        db.MockMessages.Add(infoTmp);

                    //        db.SaveChanges();

                    //    }

                    //    var cacheValue = new
                    //        {
                    //            request = requestXmlToSave,
                    //            response = ret
                    //        };
                    //    var cacheValueStr = JsonConvert.SerializeObject(cacheValue);
                    //    redis.StringSetAsync(requestXmlToSave.GetHashCode().ToString(), cacheValueStr, expiry: new TimeSpan(1, 0, 0));
                    //}
                    //ret = ret.Replace("&lt;", "<");
                    //ret = ret.Replace("&gt;",">" );
                    // HTTP PUT
                    //gizmo.Price = 80;   // Update price
                    //response = client.PostAsync(gizmoUrl,requestXML).Result;

                    //// HTTP DELETE
                    //response = client.DeleteAsync(gizmoUrl);
                }
            }
            //get uuid from query
            //get url from redis
            //post requestXML to url
            //ger return

            //write db

            return ret;
        }
    }
}
