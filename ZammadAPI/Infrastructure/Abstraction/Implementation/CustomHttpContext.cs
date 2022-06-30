using System.Web;

namespace ZammadAPI.Infrastructure.Abstraction.Implementation
{
    public class CustomHttpContext
    {
        private readonly HttpContext _httpContext;
        public string? AuthorizationToken { get; }

        public CustomHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor is null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            if (httpContextAccessor.HttpContext is null)
                throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));

            _httpContext = httpContextAccessor.HttpContext;

            if (_httpContext.Request.QueryString.Value is null)
                throw new ArgumentNullException(nameof(_httpContext));

            AuthorizationToken = HttpUtility.ParseQueryString(_httpContext.Request.QueryString.Value).Get("token");
        }
    }
}
