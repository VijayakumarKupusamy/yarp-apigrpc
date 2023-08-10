using Grpc.Core;
using GrpcGreeter;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using System.Reflection;

namespace GrpcGreeter.Services
{
    public class CaptionBuilder
    {
        public string? ClassCaption<T>() where T : class
        {
            var type = typeof(T);
            return type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;
        }
        // omitted other routines for the brevity
    }

    [DisplayName("Goods Store")]
    public record class GoodsStore(string? Name, string? Area);
    [DisplayName("Employee")]
    public record class Stuff(string? Name, string? Designation);
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var builder = new CaptionBuilder();
            var caption1 = builder.ClassCaption<GoodsStore>();
            var caption2 = builder.ClassCaption<Stuff>();

          

            return Task.FromResult(new HelloReply()
            {
                Message = "Hello " + request.Name + request.Description
            }); ;
        }

    }
}