using ContactsApi.Database;

namespace ContactsApi.Logic.Interfaces
{
    public interface ICompanyContactRepository
    {
        Task<bool> AddAsync(CompanyContact entity);
    }
}
