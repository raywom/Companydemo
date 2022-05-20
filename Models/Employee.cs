using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Sex { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    
    [Write(false)]
    public virtual Department department { get; set; }
}