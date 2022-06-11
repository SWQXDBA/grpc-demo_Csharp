using System;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;

namespace grpc_demo;

public class GrpcServerImpl:Greeter.GreeterBase
{
    class JsonMessage
    {
        
      public  string name;
      public int age;
    }
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var deserializeObject = JsonConvert.DeserializeObject<JsonMessage>(request.Request);
        Console.WriteLine(deserializeObject.name);
        Console.WriteLine(deserializeObject.age);
        Console.WriteLine(request.Request);
        deserializeObject.age++;
        var helloReply = new HelloReply();
        helloReply.Reply = JsonConvert.SerializeObject(deserializeObject);
        return Task.FromResult(helloReply);

    }
}