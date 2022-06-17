using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ZammadAPI.Infrastructure.Abstraction.Implementation
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient() ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<T> Get<T>(Uri uri, string jwtToken)
           where T : class, new()
        {
            if (uri is null)
                throw new ArgumentNullException(nameof(uri));

            if (string.IsNullOrEmpty(jwtToken))
                throw new ArgumentException($"'{nameof(jwtToken)}' cannot be null or empty.", nameof(jwtToken));

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwtToken);

            return await SendRequestWithoutContentAsync<T>(request);
        }

        public async Task<T> Post<T>(Uri uri, string jwtToken, object value)
        {
            if (uri is null)
                throw new ArgumentNullException(nameof(uri));

            if (string.IsNullOrEmpty(jwtToken))
                throw new ArgumentException($"'{nameof(jwtToken)}' cannot be null or empty.", nameof(jwtToken));

            if (value is null)
                throw new ArgumentNullException(nameof(value));

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwtToken);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await SendRequestAsync<T>(request);

        }
        private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var requestJson = await request.Content.ReadAsStringAsync();
            
            var response = _httpClient.Send(request);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something was wrong");

            return JsonSerializer.Deserialize<T>(json);
        }

        private async Task<T> SendRequestWithoutContentAsync<T>(HttpRequestMessage request)
            where T : class, new()
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var response = _httpClient.Send(request);

            StringBuilder sb = new StringBuilder();
            sb.Append(await response.Content.ReadAsStringAsync());

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something was wrong");

            // json begins and ends with []
            // zammad API return "[]" if there is no user with the received data
            // if return "[]" then return null
            // else return json

            if (sb.Length <= 4)
                return null;

            sb.Remove(0, 1);
            sb.Remove(sb.Length - 1, 1);

            var result = sb.ToString();

            return JsonSerializer.Deserialize<T>(sb.ToString());
        }
    }
}
