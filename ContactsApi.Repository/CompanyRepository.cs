using ContactsApi.Database;
using ContactsApi.Logic.Interfaces;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data;

namespace ContactsApi.Repository
{
    public class CompanyRepository : DapperRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbConnection connection, ISqlGenerator<Company> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }

        public async Task<bool> AddAsync(Company entity)
        {
            return await base.InsertAsync(entity);
        }
    }
}
