using ContactsApi.Database;
using ContactsApi.Logic.Dto;

namespace ContactsApi.Logic.Interfaces
{
    public interface IContactRepository
    {
        Task<bool> AddAsync(Contact entity);

        Task<IEnumerable<ContactDto>> GetAsync(int skip, int take);
    }
}
