using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbGet
{
    public class RedisHelp
    {
        public IDatabase DB = null;

        public RedisHelp()
        {
            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                        {
                            { "10.2.24.151", 6388}
                        }
            };

            DB = ConnectionMultiplexer.Connect(config).GetDatabase(10);
        }
    }
}