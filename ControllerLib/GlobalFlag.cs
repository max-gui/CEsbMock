using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{
    public static class EsbFlag
    {
        public static GlobalFlag GetFlag { get; set; }
    }
    public enum GlobalFlag
    {
        GetBack,
        GetThrough
    }
}
