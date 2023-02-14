using ContactsApi.Database;

namespace ContactsApi.Logic.Interfaces
{
    public interface IUserService
    {
        Task<User?> FindAsync(string email, string password);
    }
}
