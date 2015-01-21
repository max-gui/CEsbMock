using ControllerLib;
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

namespace EsbGet.Controllers
{
    public class EsbUrlController : ApiController
    {
        //private static RedisHelp RSHelp = new RedisHelp();
        [Route("EsbUrlController/Pull/lookup.ashx")]
        [HttpGet]
        public object Pull()//string UserID, string RequestType, string Environment, string timestamp, string AppID)
        {
            return new EsbUrl().Pull(this.Request);
            //return pullHelp("Pull");
        }

        [Route("EsbUrlController/Get/lookup.ashx")]
        [HttpGet]
        public object Get()
        {
            return new EsbUrl().Get(); // res;
        }

        [Route("EsbUrlController/Auto/lookup.ashx")]
        [HttpGet]
        public object Auto()//string UserID, string RequestType, string Environment, string timestamp, string AppID)
        {
            return new EsbUrl().Auto(this.Request); // pullHelp("Auto");
        }
    }
}