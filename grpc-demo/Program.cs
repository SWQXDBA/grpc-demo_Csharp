using System;
using Grpc.Core;

namespace grpc_demo
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Greeter.BindService(new GrpcServerImpl() )},
                Ports = { new ServerPort("localhost", 9090, ServerCredentials.Insecure) }
  
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + 9090);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
                    
            server.ShutdownAsync().Wait();
        }
    }
}