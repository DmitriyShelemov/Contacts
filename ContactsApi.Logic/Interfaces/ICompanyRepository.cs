using ContactsApi.Database;

namespace ContactsApi.Logic.Interfaces
{
    public interface ICompanyRepository
    {
        Task<bool> AddAsync(Company entity);
    }
}
