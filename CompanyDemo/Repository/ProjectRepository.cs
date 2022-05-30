using System.Data;
using CompanyDemo.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class ProjectRepository
{
    private IDbConnection dbConnection;

    public ProjectRepository(IConfiguration configuration)
    {
        this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public Project Create(Project project)
    {
        var sql = "INSERT INTO Project(ProjectName) " +
                  "VALUES(@ProjectName) SELECT CAST(SCOPE_IDENTITY() as int);";

        var id = dbConnection.Query<int>(sql, project).Single();
        project.Id = id;
        return project;
    }
    
    public Project Find(int id)
    {
        var sql = "SELECT * FROM Project WHERE ID = @ProjectId";
        return dbConnection.Query<Project>(sql, new {@ProjectId = id}).Single();
    }

    public List<Project> GetAll()
    {
        var sql = "SELECT * FROM Project";
        return dbConnection.Query<Project>(sql).ToList();
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Project WHERE ID = @ID";
        dbConnection.Execute(sql, new {id});
    }

    public Project Update(Project project)
    {
        var sql = "UPDATE Project SET " +
                  "ProjectName = @ProjectName " +
                  "WHERE Id = @ID";

        dbConnection.Execute(sql, project);
        return project;
    }
}