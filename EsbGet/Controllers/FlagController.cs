using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EsbGet.Controllers
{
    public class FlagController : ApiController
    {
        public string Put(bool flag)
        {
            EsbFlag.GetFlag = flag ? GlobalFlag.GetBack : GlobalFlag.GetThrough;

            return EsbFlag.GetFlag.ToString();
        }

        public string Get()
        {
            return EsbFlag.GetFlag.ToString();
        }
    }
}
