using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    
    
    [Write(false)]
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    [Write(false)]
    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}