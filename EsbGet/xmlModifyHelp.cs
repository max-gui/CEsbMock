using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace EsbGet.EsbUrlController
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
    }
}