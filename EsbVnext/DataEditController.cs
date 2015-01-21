using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;

namespace EsbVnext.controllers
{
    [Route("api/[controller]")]
    public class DataEditController : Controller
    {
        // GET: /<controller>/ 
        //[HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>() { 0, 1, 2 };
        }
    }
}
