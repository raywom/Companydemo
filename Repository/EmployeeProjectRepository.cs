using System.Data;
using CompanyDemo.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class EmployeeProjectRepository
{
    private IDbConnection dbConnection;

    public EmployeeProjectRepository(IConfiguration configuration)
    {
        this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public EmployeeProject Create(EmployeeProject employeeProject)
    {
        var sql = "INSERT INTO EmployeeProject(EmployeeId, ProjectId) " +
                  "VALUES(@EmployeeId, @ProjectId) SELECT CAST(SCOPE_IDENTITY() as int);";

        var id = dbConnection.Query<int>(sql, employeeProject).Single();
        employeeProject.Id = id;
        return employeeProject;
    }
    
    public EmployeeProject Find(int id)
    {
        var sql = "SELECT * FROM EmployeeProject WHERE ID = @Id";
        return dbConnection.Query<EmployeeProject>(sql, new {@EmployeeProject = id}).Single();
    }

    public List<EmployeeProject> GetAll()
    {
        var sql = "SELECT * FROM EmployeeProject, Employees, Project WHERE EmployeeProject.EmployeeId = Employees.Id AND EmployeeProject.ProjectId = Project.Id";
        return dbConnection.Query<EmployeeProject>(sql).ToList();
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM EmployeeProject WHERE ID = @ID";
        dbConnection.Execute(sql, new {id});
    }

    public EmployeeProject Update(EmployeeProject employeeProject)
    {
        var sql = "UPDATE EmployeeProject SET " +
                  "EmployeeId = @EmployeeId, " +
                  "ProjectId = @ProjectId WHERE Id = @ID";

        dbConnection.Execute(sql, employeeProject);
        return employeeProject;
    }
}