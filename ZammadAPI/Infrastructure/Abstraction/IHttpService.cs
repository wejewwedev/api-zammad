namespace ZammadAPI.Infrastructure.Abstraction
{
    public interface IHttpService
    {
        Task<T> Get<T>(Uri uri, string token) 
            where T : class, new();
        Task<T> Post<T>(Uri uri, string token, object value);
    }
}
