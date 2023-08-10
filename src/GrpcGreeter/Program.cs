
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Enrichers.Span;
using System.Diagnostics;
using System.IO;


var builder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args);
builder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                        .ReadFrom
                        .Configuration(hostingContext.Configuration)
                        .Enrich.With<ActivityEnricher>()
                        .Enrich.FromLogContext()
                        ).ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseStartup<ApiServerHost>();
                        }).Build().Run();


                        // Additional configuration is required to successfully run gRPC on macOS.
                        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

                        // Add services to the container.
                       

 


