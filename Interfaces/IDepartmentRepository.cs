using CompanyDemo.Models;

namespace CompanyDemo.Repository;

public interface IDepartmentRepository
{
    Department Find(int id);
    List<Department> GetAll();
    Department Create(Department department);

    Department Update(Department department);

    void Delete(int id);
}