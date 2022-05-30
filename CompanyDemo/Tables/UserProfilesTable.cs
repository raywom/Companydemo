using System.Data;
using AspNetCore.Identity.Dapper;
using CompanyDemo.Abstract;
using CompanyDemo.Models;
using Dapper;

namespace CompanyDemo.Tables
{
    public class UserProfilesTable : TableBase, IUserProfilesTable
    {
        public IDbConnection DbConnection { get; set; }

        public UserProfilesTable(IDbConnectionFactory _dbConnectionFactory)
        {
            DbConnection = _dbConnectionFactory.Create();
        }

        protected override void OnDispose()
        {
            if (DbConnection != null)
                DbConnection.Dispose();
        }

        public async Task<bool> CreateAsync(UserProfile userProfile)
        {
            const string sql = "INSERT INTO [dbo].[UserProfiles] " +
                              "VALUES (@Email, @UserId);";
            var rowsInserted = await DbConnection.ExecuteAsync(sql, new
            {
                userProfile.Email,
                userProfile.UserId
            });
            return rowsInserted == 1;
        }
    }
}
