using MockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ControllerLib;

namespace EsbGet.Controllers
{
    public class DataEditController : ApiController
    {
        [Route("api/request2Key")]
        [HttpPost]
        public string Request2Key([FromBody]string request)
        {
            return new DataEdit().Request2Key(request);
        }

        public MockMessage GetByKey(string key)
        {
            return new DataEdit().GetByKey(key);
        }

        public List<MockMessage> GetByComment([FromUri]string comment)
        {
            return new DataEdit().GetByComment(comment);
        }

        public List<MockMessage> Get()
        {
            return new DataEdit().Get();
        }

        public string Post(PostMessage Data)
        {
            return new DataEdit().Post(Data);
        }


        public string Put(PutMessage data)
        {
            return new DataEdit().Put(data);
        }

        public bool Delete(string reqKey)
        {
            return new DataEdit().Delete(reqKey);
        }
    }
}
