using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitRpcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var rpcClient = new EsbGet.RabbitRpcHelp.RPCClient();


                //Console.WriteLine(" [x] Requesting fib(30)");
                var res = rpcClient.Call("m" + i.ToString() + "-");
                //Console.WriteLine(" [.] Got '{0}'", response);

                rpcClient.Close();

                Console.WriteLine(res);
            }
        }
    }
}
