using ZammadAPI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Security.Claims;

namespace ZammadAPI.Infrastructure.Abstraction.Implementation
{
    public class CustomHttpContext
    {
        private readonly HttpContext _httpContext;
        public string AuthorizationToken { get; }
        public CustomHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor is null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            if (httpContextAccessor.HttpContext is null)
                throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));

            _httpContext = httpContextAccessor.HttpContext;
            AuthorizationToken = _httpContext.Request.Headers.Authorization[0].ClearOf(authorizationType: "bearer");
        }
    }
}
