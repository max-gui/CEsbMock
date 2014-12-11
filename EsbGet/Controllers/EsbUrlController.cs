using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EsbGet.Controllers
{
	public class EsbUrlController : ApiController
	{
		public object Get()
		{
			object obj = null;
			var res = new
			{
				ErrorMessage	=	obj,
		
				Factor	=	0,
		
				IsValid	=	true,
		
				RTClass	=	0,
		
				RequestTypeID	=	41041901,
		
				SaveFailLog	=	false,
		
				SaveFullLog	=	false,
		
				SaveLog	=	false,
		
				Timeout	=	60,
		
				Timestamp	=	"2014-12-11 19:31:08",
		
				WSName	=	"Payment.Base.MerchantService",

				WSUrl = "http://10.2.8.70:8059/Asmx/webservice1.asmx",
		
				WebServiceID	=	410419

			};

			return res;
		}
	}
}
