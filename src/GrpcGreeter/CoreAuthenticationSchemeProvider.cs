using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace GrpcGreeter
{
    public class CoreAuthenticationSchemeProvider : AuthenticationSchemeProvider
    {
        private readonly ILogger<CoreAuthenticationSchemeProvider> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoreAuthenticationSchemeProvider(
            ILogger<CoreAuthenticationSchemeProvider> logger,
            IOptions<AuthenticationOptions> options,
            IHttpContextAccessor httpContextAccessor
            ) : base(options)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Retrieves the scheme on per-request basis
        /// </summary>
        /// <returns></returns>
        public override Task<AuthenticationScheme> GetDefaultAuthenticateSchemeAsync()
        {
            try
            {
                var ctxt = _httpContextAccessor.HttpContext;

                var authHeader = ctxt.Request.Headers[HeaderNames.Authorization];
                if (authHeader.Count > 0)
                {
                    var incomingScheme = authHeader.FirstOrDefault().Split(' ').FirstOrDefault();

                    return GetSchemeAsync(incomingScheme);
                }
                else
                    return base.GetDefaultAuthenticateSchemeAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError($"@@@@ GetDefaultAuthenticateSchemeAsync Error: {ex}");

                return base.GetDefaultAuthenticateSchemeAsync();
            }
        }
    }
}
