using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{
    public class FlagEdit
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
