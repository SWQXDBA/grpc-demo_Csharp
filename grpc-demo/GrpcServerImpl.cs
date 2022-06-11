using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace grpc_demo;

public class GrpcServerImpl:Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        Console.WriteLine(request.Request);
        var helloReply = new HelloReply();
        helloReply.Reply = "from c# reply::" + request.Request;
        return Task.FromResult(helloReply);

    }
}