using ZammadAPI.Data.ZammadModels;
using System.Threading.Tasks;
using ZammadAPI.Infrastructure.Extensions;
using ZammadAPI.Data.Dtos.Zammad;

namespace ZammadAPI.Infrastructure.Abstraction.Implementation
{
    public class ZammadUserService
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;

        public ZammadUserService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(httpService));
        }
        public async Task Create(UserCreateDto user, string token)
        {
            UriBuilder uriBuilder = new($"{_configuration.GetValue<string>("ZammadServerAddress")}api/v1/users");
            await _httpService.Post<User>(uriBuilder.Uri, token, user);
        }

        public async Task<User> SearchByLogin(string login, string token)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));

            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException($"'{nameof(token)}' cannot be null or whitespace.", nameof(token));

            UriBuilder uriBuilder = new($"{_configuration.GetValue<string>("ZammadServerAddress")}api/v1/users/search?query=login:{login}");

            return await _httpService.Get<User>(uriBuilder.Uri, token);
        }
    }
}

            