using System.Data;
using CompanyDemo.Models;

namespace CompanyDemo.Abstract
{
    public interface IUserProfilesTable
    {
        IDbConnection DbConnection { get; set; }
        Task<bool> CreateAsync(UserProfile user);
    }
}
