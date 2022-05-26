using System.Data;
using System.Security.Claims;
using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class UserRepository : IUserRepository
{
    private IDbConnection dbConnection;
    private IHttpContextAccessor _httpContextAccessor;

    public UserRepository(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
    
    public User Create(User user)
    {
        var id = dbConnection.Insert(user);
        user.Id = (int)id;
        return user;
    }
    
    public List<User> GetAll()
    {
        return dbConnection.GetAll<User>().ToList();
    }
    
    public User Find(string email, string password)
    {
        var sql = "SELECT * FROM Users WHERE Email = @UserEmail AND Password = @UserPassword";
        return dbConnection.Query<User>(sql, new{@Email = email, @Password = password}).Single();
    }
    
    public string GetMyName()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        return result;
    }
    
    public void Delete(int id)
    {
        dbConnection.Delete(new User(){ Id = id });

    }

    public User Update(User user)
    {
        dbConnection.Update(user);
        return user;
    }
}
