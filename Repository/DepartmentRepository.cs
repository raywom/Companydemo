using System.Data;
using CompanyDemo.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private IDbConnection dbConnection;

    public DepartmentRepository(IConfiguration configuration)
    {
        this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public Department Create(Department department)
    {
        var sql = "INSERT INTO Department(DeptName, MgrId) " +
                  "VALUES(@DeptName, @MgrId) SELECT CAST(SCOPE_IDENTITY() as int);";

        var id = dbConnection.Query<int>(sql, department).Single();
        department.Id = id;
        return department;
    }
    
    public Department Find(int id)
    {
        var sql = "SELECT * FROM Department WHERE ID = @DepartmentId";
        return dbConnection.Query<Department>(sql, new {@DepartmentId = id}).Single();
    }

    public List<Department> GetAll()
    {
        var sql = "SELECT * FROM Department, Employee";
        return dbConnection.Query<Department>(sql).ToList();
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Department WHERE ID = @ID";
        dbConnection.Execute(sql, new {id});
    }

    public Department Update(Department department)
    {
        var sql = "UPDATE Department SET " +
                  "DeptName = @DeptName, " +
                  "MgrId = @MgrId WHERE Id = @ID";

        dbConnection.Execute(sql, department);
        return department;
    }
}