using ContactsApi.Database;
using ContactsApi.Logic.Interfaces;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data;

namespace ContactsApi.Repository
{
    public class UserRepository : DapperRepository<User>, IUserRepository
    {
        public UserRepository(IDbConnection connection, ISqlGenerator<User> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await FindAsync(x => x.Email == email);
        }
    }
}
