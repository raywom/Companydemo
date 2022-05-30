using CompanyDemo.Models;

namespace CompanyDemo.Interfaces;

public interface IEmployeeRepository
{
    Employee Find(int id);
    List<Employee> FindByDepartmentId(int departmentId);
    List<Employee> GetAll();
    Employee Create(Employee employee);

    Employee Update(Employee employee);

    void Delete(int id);
}