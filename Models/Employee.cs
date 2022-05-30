using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class Employee
{
    [Dapper.Contrib.Extensions.Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Sex { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    
    [Write(false)]
    public virtual Department Department { get; set; }
    [Write(false)]
    public virtual ICollection<Project> Projects { get; set; }
    [Write(false)]
    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}