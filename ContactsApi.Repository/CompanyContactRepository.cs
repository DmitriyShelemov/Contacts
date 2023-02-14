using ContactsApi.Database;
using ContactsApi.Logic.Interfaces;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data;

namespace ContactsApi.Repository
{
    public class CompanyContactRepository : DapperRepository<CompanyContact>, ICompanyContactRepository
    {
        public CompanyContactRepository(IDbConnection connection, ISqlGenerator<CompanyContact> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }

        public async Task<bool> AddAsync(CompanyContact entity)
        {
            return await base.InsertAsync(entity);
        }
    }
}
