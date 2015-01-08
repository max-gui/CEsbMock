using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbRedisHelp
{
    public static class RedisHelp
    {
        public static IDatabase DB = null;

        static RedisHelp()
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
