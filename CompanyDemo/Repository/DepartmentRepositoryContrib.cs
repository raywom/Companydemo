using System.Data;
using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class DepartmentRepositoryContrib : IDepartmentRepository
{
    private IDbConnection dbConnection;

    public DepartmentRepositoryContrib(IConfiguration configuration)
    {
        this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public Department Create(Department department)
    {
        var id = dbConnection.Insert(department);
        department.Id = (int)id;
        return department;
    }

    public Department Find(int id)
    {
        return dbConnection.Get<Department>(id);
    }

    public List<Department> GetAll()
    {
        return dbConnection.GetAll<Department>().ToList();
    }

    public void Delete(int id)
    {
        dbConnection.Delete(new Department(){ Id = id });

    }

    public Department Update(Department department)
    {
        dbConnection.Update(department);
        return department;
    }
}