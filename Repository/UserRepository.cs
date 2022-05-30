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
    
    // public User Create(User user)
    // {
    //     var sql = "INSERT INTO Department(DeptName, MgrId) " +
    //               "VALUES(@DeptName, @MgrId) SELECT CAST(SCOPE_IDENTITY() as int);";
    //
    //     var sql = "INSERT INTO User(FirstName, LastName, Email, Password, DepartmentId) " +
    //               "VALUES(@FirstName, @LastName, @Email, @Password, @DepartmentId) SELECT CAST(SCOPE_IDENTITY() as int);";
    //     var id = dbConnection.Query<string>(sql, user).Single();
    //     user.Id = id;
    //     return user;
    // }
    
    public List<User> GetAll()
    {
        return dbConnection.GetAll<User>().ToList();
    }

    public User Create(User user)
    {
        throw new NotImplementedException();
    }

    public User Find(string email, string password)
    {
        var sql = "SELECT * FROM Users WHERE Email = @UserEmail AND Password = @UserPassword";
        return dbConnection.Query<User>(sql, new{@Email = email, @Password = password}).Single();
    }

    public User Find(string id)
    {
        var sql = "SELECT * FROM Users WHERE Id = @UserId";
        return dbConnection.Query<User>(sql, new{@Id = id}).Single();
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
    
    public void Delete(string id)
    {
        dbConnection.Delete(new User(){ Id = id });

    }

    public User Update(User user)
    {
        dbConnection.Update(user);
        return user;
    }
}
