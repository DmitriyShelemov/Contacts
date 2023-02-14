using ContactsApi.Database;
using ContactsApi.Logic.Dto;
using ContactsApi.Logic.Interfaces;
using Dapper;
using System.Data;

namespace ContactsApi.Repository
{
    public class ContactRepository : IContactRepository
    {
        #region Queries

        private const string GET_QUERY =
            @"SELECT 
                cc.Id BusinessInfoId, 
                c.Id ContactId, 
                cp.Id CompanyId, 
                (c.FirstName + ' ' + c.LastName) [Name], 
                cp.[Name] CompanyName, 
                cc.Position, 
                c.CreateDate, 
                c.LastContactedDate
                FROM dbo.Contacts c
                JOIN dbo.CompanyContacts cc ON cc.ContactId = c.Id
                JOIN dbo.Companies cp ON cp.Id = cc.CompanyId
                ORDER BY c.Id, cc.Id
                OFFSET     @skip ROWS
                FETCH NEXT @take ROWS ONLY";

        private const string ADD_QUERY =
            @"INSERT INTO dbo.Contacts(
                [FirstName]
                ,[LastName]
                ,[MiddleName]
                ,[TitleType]
                ,[Notes]
                ,[CountryId]
                ,[ZipCode]
                ,[Address]
                ,[StateId]
                ,[City]
                ,[PersonalMobile1]
                ,[PersonalMobile2]
                ,[HomePhone]
                ,[LinkedIn]
                ,[PersonalEmail]
                ,[DateOfBirth]
                ,[CreateDate]
                ,[LastContactedDate])
                VALUES(
                @FirstName
                ,@LastName
                ,@MiddleName
                ,@TitleType
                ,@Notes
                ,@CountryId
                ,@ZipCode
                ,@Address
                ,@StateId
                ,@City
                ,@PersonalMobile1
                ,@PersonalMobile2
                ,@HomePhone
                ,@LinkedIn
                ,@PersonalEmail
                ,@DateOfBirth
                ,GETDATE()
                ,GETDATE());
            
            SELECT SCOPE_IDENTITY()";

        #endregion

        private readonly IDbConnection _connection;

        public ContactRepository(IDbConnection connection) 
        {
            _connection = connection;
        }

        public async Task<bool> AddAsync(Contact entity)
        {
            var result = await _connection.ExecuteScalarAsync<long>(ADD_QUERY, new
            {
                entity.FirstName,
                entity.LastName,
                entity.MiddleName,
                entity.TitleType,
                entity.Notes,
                entity.CountryId,
                entity.ZipCode,
                entity.Address,
                entity.StateId,
                entity.City,
                entity.PersonalMobile1,
                entity.PersonalMobile2,
                entity.HomePhone,
                entity.LinkedIn,
                entity.PersonalEmail,
                entity.DateOfBirth
            });

            entity.Id = result;

            return result >= 1;
        }

        public async Task<IEnumerable<ContactDto>> GetAsync(int skip, int take)
        {
            return await _connection.QueryAsync<ContactDto>(GET_QUERY, new { skip, take });
        }
    }
}