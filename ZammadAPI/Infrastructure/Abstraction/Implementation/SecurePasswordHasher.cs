using System.Security.Cryptography;
using System.Text;

namespace ZammadAPI.Infrastructure.Abstraction.Implementation
{
    public class SecurePasswordHasher
    {
        public string Hash(string firstName, string lastName, string middleName, string organization, string email)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException($"'{nameof(middleName)}' cannot be null or empty.", nameof(middleName));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException($"'{nameof(organization)}' cannot be null or empty.", nameof(organization));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));

            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(firstName + lastName + middleName + organization + email));

            return Convert.ToBase64String(hash).Substring(0, 10);
        }
    }
}
