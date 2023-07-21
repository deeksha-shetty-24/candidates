using Candidate.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Candidate.Web.Infrastructure
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IMemoryCache _memoryCache;
        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IMemoryCache memoryCache) : base(options, logger, encoder, clock)
        {
            _memoryCache = memoryCache;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyAuthenticationOptions.HeaderName, out var apiKey) || apiKey.Count != 1)
            {
                Logger.LogWarning("An API request was received without the x-api-key header");
                return AuthenticateResult.Fail("Invalid parameters");
            }
            Request.Headers.TryGetValue("UserId", out var userId);
            var token = _memoryCache.Get(Convert.ToInt32(userId.ToString()));

            if (Convert.ToString(apiKey) == Convert.ToString(token))
            {
                var claims = new[] { new Claim(ClaimTypes.Name, userId.ToString()) };
                var identity = new ClaimsIdentity(claims, ApiKeyAuthenticationOptions.DefaultScheme);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, ApiKeyAuthenticationOptions.DefaultScheme);

                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.Fail("Not Auth");
        }
    }
}
