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
using gRPCUnary;
using Microsoft.AspNetCore.Authorization;

namespace gRPCUnary.Services
{
    public class UsersService : UsersData.UsersDataBase
    { 
        private readonly ILogger<UsersService> _logger;
        private UserRepeated UserRepeated { get; set; } = new UserRepeated();
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public override async Task<UserResponse> SaveUsers(UserRepeated request, ServerCallContext context)
        {
            var requester = context.RequestHeaders.Get("requester");

            
            foreach (var userDet in request.UserDetails)
            {
                UserRepeated.UserDetails.Add(userDet);
            }
            return await Task.FromResult(new UserResponse());
        }
        public override async Task<UserResponse> SaveUser(UserDetails request,ServerCallContext context)
        {
            var requester = context.RequestHeaders.Get("requester");
            UserRepeated.UserDetails.Add(request);
            return  await Task.FromResult(new UserResponse());
        }
        public override async Task<UserRepeated> GetUsers(UserRequest request,ServerCallContext context)
        {
            var requester = context.RequestHeaders.Get("requester");
            return await Task.FromResult(UserRepeated);
        }
    }
}