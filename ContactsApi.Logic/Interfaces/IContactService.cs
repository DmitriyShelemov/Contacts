using ContactsApi.Logic.Dto;
namespace ContactsApi.Logic.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAsync(int skip, int take);

        Task<bool> AddAsync(ContactCreateDto dto);
    }
}
