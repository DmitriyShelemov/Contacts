using ContactsApi.Database;
using ContactsApi.Logic.Dto;

namespace ContactsApi.Logic.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
    }
}
