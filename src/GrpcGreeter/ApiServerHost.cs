using GPRCStreaming;
using GrpcGreeter.Services;
using gRPCUnary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GrpcGreeter.Services;
using gRPCUnary;
using GPRCStreaming;
using gRPCUnary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;

internal class ApiServerHost
{
    private ILogger _logger;
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _webHostEnvironment;


    public ApiServerHost(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        _configuration = configuration;
        _webHostEnvironment = webHostEnvironment;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = "grpc://localhost:5002",
                   ValidAudience = "grpc://localhost:5002",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"))
               };
           });
        services.AddAuthorization(options =>
        {
            // indicates that authorization should fail immediately after
            // first failed policy and not to proceed to any other pending policies
            options.InvokeHandlersAfterFailure = false;

            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireAssertion(context =>
                {
                    // this code should newer be executed on unauthenticated request

                    return true;// context.User.Identity.IsAuthenticated;
                })
                .Build();
        }); 
        services.AddGrpc();
        services.AddGrpcReflection();
    }
    public void Configure(IApplicationBuilder app,
                             IHostEnvironment env,
                             ILoggerFactory loggerFactory
                           )
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => 
        {
            
     

            endpoints.MapGrpcService<GreeterService>();
            endpoints.MapGrpcService<LocationDataService>();
            endpoints.MapGrpcService<UsersService>();
            endpoints.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            endpoints.MapGrpcReflectionService();
        });
        
       
    }
}