using EsbMockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace EsbGet.EsbUrlController.Pull
{
    /// <summary>
    /// Summary description for PullHelp
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PullHelp : System.Web.Services.WebService
    {

        [WebMethod]
        public string Request(string requestXML)
        {

            var tag = this.Context.Request.QueryString["tag"];
            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                        {
                            { "10.2.24.151", 6388}
                        }
            };

            var redis = ConnectionMultiplexer.Connect(config).GetDatabase(10);
            var tagValue = redis.StringGet(tag);//.StringSet(tag, realUrl, expiry: new TimeSpan(0, 10, 0));// subscribeSelfFilter(redis, subItem, waitTime, (e) => true);
            //redis.StringSet(tag, tagValue, expiry: new TimeSpan(0, 0, 1));

            var a = JObject.Parse(tagValue);
            var realUrl = a["WSUrl"].ToString();//"http://ws.bill.payment.fws.qa.nt.ctripcorp.com/payment-base-merchantservice/merchantservice.asmx";
            var wsName = a["WSName"].ToString();
            var webServiceId = a["WebServiceId"].ToString(); var ret = string.Empty;

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://ws.bill.payment.fws.qa.nt.ctripcorp.com/payment-base-merchantservice/merchantservice.asmx");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                //client.DefaultRequestHeaders.Add("Content-Type", "text/xml");


                var requestXMLForPost = requestXML;
                requestXMLForPost = requestXMLForPost.Replace("&", "&amp;");
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
                                    WebServiceId = webServiceId,
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
