using GPRCStreaming;
using Grpc.Core;
using GrpcGreeter;
using System.IO.Pipelines;
using System.Threading.Tasks; 
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using System.Linq;
using System;
using System.IO;
namespace GPRCStreaming
{
    public class LocationDataService : LocationData.LocationDataBase
    {
       // private readonly FileReader _fileReader;
        private readonly ILogger<LocationDataService> _logger;

        public LocationDataService(ILogger<LocationDataService> logger)
        {
            _logger = logger;
        }

        public override async Task GetLocations(GetLocationsRequest request, IServerStreamWriter<GetLocationsResponse> responseStream, ServerCallContext context)
        {
            try
            {
                _logger.LogInformation("Incoming request for GetLocationData");


                var dataLimit = 10;

                for (var i = 0; i <= dataLimit - 1; i++)
                {

                    await responseStream.WriteAsync(new GetLocationsResponse
                    {
                        LatitudeE7 = dataLimit+5+i,
                        LongitudeE7 = dataLimit + 10 + i
                    });
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error occurred");
                throw;
            }
        }
    }
}