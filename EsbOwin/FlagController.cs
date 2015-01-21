using ControllerLib;
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
            return new FlagEdit().Put(flag);
            //EsbFlag.GetFlag = flag ? GlobalFlag.GetBack : GlobalFlag.GetThrough;

            //return EsbFlag.GetFlag.ToString();
        }

        public string Get()
        {
            return new FlagEdit().Get();//.Put(flag);
            //return EsbFlag.GetFlag.ToString();
        }
    }
}
