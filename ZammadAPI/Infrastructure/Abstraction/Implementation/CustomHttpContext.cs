using System.Web;

namespace ZammadAPI.Infrastructure.Abstraction.Implementation
{
    public class CustomHttpContext
    {
        private readonly HttpContext _httpContext;
        public string? AuthorizationToken { get; }
        public bool TokenIsReceived;

        public CustomHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor is null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            if (httpContextAccessor.HttpContext is null)
                throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));

            _httpContext = httpContextAccessor.HttpContext;

            if (_httpContext.Request.QueryString.Value is null)
                throw new ArgumentNullException(nameof(_httpContext));

            /// <summary> 
            /// Проверяем, пришел ли токен из приложения
            /// Если нет, присваиваем переменной JwtTokenIsValid false
            /// Если пришел, true
            /// </summary>

            var jwtToken = HttpUtility.ParseQueryString(_httpContext.Request.QueryString.Value).Get("token");

            if (string.IsNullOrEmpty(jwtToken))
            {
                TokenIsReceived = false;
            }
            else
            {
                AuthorizationToken = jwtToken;
                TokenIsReceived = true;
            }
        }
    }
}
