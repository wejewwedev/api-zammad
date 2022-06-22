using ZammadAPI.Infrastructure.Exceptions;
using ZammadAPI.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using ZammadAPI.Data.Dtos.Zammad;

namespace ZammadAPI.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static UserCreateDto PopulateObjectFromJwtToken(this UserCreateDto model, JwtSecurityToken jwtToken)
        {
            if (jwtToken is null)
                throw new ArgumentNullException(nameof(jwtToken));

            if (jwtToken.Claims is null)
                throw new ArgumentNullException(nameof(jwtToken.Claims));

            if (!jwtToken.Claims.Any())
                throw new CollectionHaveNotAnyEntityException(nameof(jwtToken.Claims));

            var firstName = jwtToken.Claims.FirstOrDefault(e => e.Type == "firstname");
            var lastName = jwtToken.Claims.FirstOrDefault(e => e.Type == "lastname");
            var middleName = jwtToken.Claims.FirstOrDefault(e => e.Type == "middlename");
            var organization = jwtToken.Claims.FirstOrDefault(e => e.Type == "organization");
            var email = jwtToken.Claims.FirstOrDefault(e => e.Type == "email");
            var login = email;

            if (firstName is null || string.IsNullOrEmpty(firstName.Value))
                throw new NullReferenceException(nameof(firstName));

            if (lastName is null || string.IsNullOrEmpty(lastName.Value))
                throw new NullReferenceException(nameof(lastName));

            if (middleName is null || string.IsNullOrEmpty(middleName.Value))
                throw new NullReferenceException(nameof(middleName));

            if (organization is null || string.IsNullOrEmpty(organization.Value))
                throw new NullReferenceException(nameof(organization));

            if (email is null || string.IsNullOrEmpty(email.Value))
                throw new NullReferenceException(nameof(email));

            model.FirstName = firstName.Value;
            model.LastName = lastName.Value;
            model.MiddleName = middleName.Value;
            model.Organization = organization.Value;
            model.Email = email.Value;
            model.Login = model.Email;

            return model;
        }
        //public static string ClearOf(this string str)
        //{
        //    if (str.ToLower().Contains("basic"))
        //        return str.Remove(0, 5).Trim();

        //    if (str.ToLower().Contains("bearer"))
        //        return str.Remove(0, 6).Trim();

        //    if (str.ToLower().Contains("?token="))
        //        return str.Remove(0, 7).Trim();

        //    return str;
        //}

    }
}
