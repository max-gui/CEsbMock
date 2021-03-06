﻿using ControllerLib;
using EsbRabbitHelp;
using EsbRedisHelp;
using MockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ControllerLib
{
    public class EsbUrl
    {
        public object Pull(HttpRequestMessage request)//string UserID, string RequestType, string Environment, string timestamp, string AppID)
        {
            return pullHelp("Pull", request);
        }

        private object pullHelp(string urlPara, HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://soa.fws.qa.nt.ctripcorp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ttStr = "&timestamp=";
                var ttIndex = request.RequestUri.Query.IndexOf(ttStr);
                var tailStr = request.RequestUri.Query.Substring(ttIndex + ttStr.Length);
                var queryStr = request.RequestUri.Query.Remove(ttIndex) + tailStr.Substring(tailStr.IndexOf("&"));
                // HTTP GET
                var response = client.GetAsync("soa.esb/lookup.ashx" + queryStr);
                var respResult = response.Result;
                if (respResult.IsSuccessStatusCode)
                {
                    var product = respResult.Content.ReadAsStringAsync().Result;

                    var a = JObject.Parse(product);
                    var realUrl = a["WSUrl"].ToString();
                    var wsName = a["WSName"].ToString();
                    var webServiceId = a["WebServiceID"].ToString();
                    a["WSUrl"] = string.Format("http://10.2.8.70:8059/EsbGet/EsbUrlController/{0}/Ctrip.SOA.ESB.asmx", urlPara); //string.Format("http://10.2.8.70:8059/EsbGet/EsbUrlController/{0}/{0}Help.asmx", urlPara);

                    var reqTmp = new RequestTypeInfo
                    {
                        RequestType = request.GetQueryNameValuePairs().ToList()[1].Value.ToLower(),
                        ServiceType = new ServiceTypeInfo
                        {
                            WebServiceId = webServiceId,
                            WsUrl = realUrl,
                            WSName = wsName
                        }
                    };

                    var callmessage = JsonConvert.SerializeObject(reqTmp);

                    var messageClient = new MessageClient();

                    messageClient.Send(callmessage, PipeName.EsbRequestInfoIn.ToString());

                    var res = new
                    {
                        ErrorMessage = a["ErrorMessage"],

                        Factor = a["Factor"],

                        IsValid = a["IsValid"],

                        RTClass = a["RTClass"],

                        RequestTypeID = a["RequestTypeID"],

                        SaveFailLog = a["SaveFailLog"],

                        SaveFullLog = a["SaveFullLog"],

                        SaveLog = a["SaveLog"],

                        Timeout = a["Timeout"],

                        Timestamp = a["Timestamp"],

                        WSName = a["WSName"],

                        WSUrl = a["WSUrl"],//"http://localhost/CtripEsbAsmx/WebService1.asmx",//"http://10.2.8.70:8059/Asmx/webservice1.asmx",

                        WebServiceID = a["WebServiceID"]

                    };

                    return res;
                }
            }

            return null;
        }

        public object Get()
        {
            object obj = null;
            var res = new
            {
                ErrorMessage = obj,

                Factor = 0,

                IsValid = true,

                RTClass = 0,

                RequestTypeID = 41041901,

                SaveFailLog = false,

                SaveFullLog = false,

                SaveLog = false,

                Timeout = 60,

                Timestamp = "2014-12-11 19:31:08",

                WSName = "Payment.Base.MerchantService",

                WSUrl = "http://10.2.8.70:8059/EsbGet/EsbUrlController/Get/Ctrip.SOA.ESB.asmx",//"http://10.2.8.70:8059/EsbGet/EsbUrlController/Get/GetHelp.asmx",//"http://localhost/CtripEsbAsmx/WebService1.asmx",//"http://10.2.8.70:8059/Asmx/webservice1.asmx",

                WebServiceID = 410419

            };

            return res;
        }

        public object Auto(HttpRequestMessage request)//string UserID, string RequestType, string Environment, string timestamp, string AppID)
        {
            return pullHelp("Auto", request);
        }
    }
}