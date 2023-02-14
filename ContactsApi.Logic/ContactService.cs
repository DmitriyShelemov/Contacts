using ContactsApi.Database;
using ContactsApi.Logic.Dto;
using ContactsApi.Logic.Interfaces;
using System.Threading.Tasks.Dataflow;
using System.Transactions;

namespace ContactsApi.Logic
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyContactRepository _companyContactRepository;

        public ContactService(
            IContactRepository contactRepository, 
            ICompanyRepository companyRepository, 
            ICompanyContactRepository companyContactRepository)
        {
            _contactRepository = contactRepository;
            _companyRepository = companyRepository;
            _companyContactRepository = companyContactRepository;
        }

        public async Task<bool> AddAsync(ContactCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (dto.Company != null)
                {
                    if (!await _companyRepository.AddAsync(dto.Company))
                        return false;

                    dto.BusinessInfo.CompanyId = dto.Company.Id;
                }
                else
                {
                    dto.BusinessInfo.CompanyId = dto.CompanyId.GetValueOrDefault();
                }

                if (!await _contactRepository.AddAsync(dto))
                    return false;

                dto.BusinessInfo.ContactId = dto.Id;

                if (!await _companyContactRepository.AddAsync(dto.BusinessInfo))
                    return false;

                tran.Complete();
                return true;
            }
        }

        public async Task<IEnumerable<ContactDto>> GetAsync(int skip, int take)
        {
            return await _contactRepository.GetAsync(skip, take);
        }
    }
}