using CompanyDemo.Models;

namespace CompanyDemo.Interfaces;

public interface IEmployeeProject
{
    EmployeeProject Find(int id);
    List<EmployeeProject> GetAll();
    EmployeeProject Create(EmployeeProject employeeProject);

    EmployeeProject Update(EmployeeProject employeeProject);

    void Delete(int id);
}