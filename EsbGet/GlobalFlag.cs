using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbGet
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