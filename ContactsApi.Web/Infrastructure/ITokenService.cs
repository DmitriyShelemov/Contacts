using ContactsApi.Database;

namespace ContactsApi.Web.Infrastructure
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}