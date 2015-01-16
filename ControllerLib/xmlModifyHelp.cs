using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ControllerLib
{
    public static class xmlModifyHelp
    {
        public static void removeUnNeededTag(this XmlDocument reqXml)
        {
            var xmlReqTmp = reqXml.SelectSingleNode("Request/Header") as XmlElement;
            if (xmlReqTmp != null)
                xmlReqTmp.RemoveAttribute("ClientIP");

            xmlReqTmp = reqXml.SelectSingleNode("Request/Header") as XmlElement;
            if (xmlReqTmp != null)
                xmlReqTmp.RemoveAttribute("RequestID");
        }

        public static string FormatRequestBody(this XmlDocument reqXml)
        {
            reqXml.removeUnNeededTag();
            return reqXml.InnerXml;
        }

        public static string GetRequestType(this XmlDocument reqXml)
        {
            var xmlReqTmp = reqXml.SelectSingleNode("Request/Header") as XmlElement;
            var requestType = xmlReqTmp.Attributes["RequestType"].InnerText;
            return requestType;
        }
    }
}