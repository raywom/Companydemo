using System.Data;
using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private IDbConnection dbConnection;

    public EmployeeRepository(IConfiguration configuration)
    {
        this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public Employee Create(Employee employee)
    {
        var id = dbConnection.Insert(employee);
        employee.Id = (int)id;
        return employee;
    }

    public Employee Find(int id)
    {
        return dbConnection.Get<Employee>(id);
    }

    public List<Employee> FindByDepartmentId(int departmentId)
    {
        return dbConnection.Query<Employee>("SELECT * FROM Employees WHERE DepartmentId = @departmentId", new { departmentId }).ToList();
    }
    public List<Employee> GetAll()
    {
        return dbConnection.GetAll<Employee>().ToList();
    }

    public void Delete(int id)
    {
        dbConnection.Delete(new Employee(){ Id = id });

    }

    public Employee Update(Employee employee)
    {
        dbConnection.Update(employee);
        return employee;
    }
}