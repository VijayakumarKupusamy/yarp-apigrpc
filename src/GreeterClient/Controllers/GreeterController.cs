using System.Threading.Tasks;
using GreeterClient;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
namespace Greeter
{
    [ApiController]
    [Route("[controller]")]
    public class GreeterController : ControllerBase
    {

        // POST: GreeterController/SayHello
        [HttpPost]
        [Route("Hello")]
        public async Task<IActionResult> SayHello([FromBody] HelloRequest helloRequest)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5002");
            var client = new GreeterClient.Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new GreeterClient.HelloRequest { Name = helloRequest.Name });
            return  Ok(reply);
        }

    }
}
