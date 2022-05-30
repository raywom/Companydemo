using CompanyDemo.Models;

namespace CompanyDemo.Repository;

public interface IProjectRepository
{
    Project Find(int id);
    List<Project> GetAll();
    Project Create(Project project);

    Project Update(Project project);

    void Delete(int id);
}