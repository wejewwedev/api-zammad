namespace ZammadAPI.Infrastructure.Exceptions
{
    public class CollectionHaveNotAnyEntityException : Exception
    {
        public CollectionHaveNotAnyEntityException(string? message)
            : base(message)
        {

        }
    }
}
