using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

[Dapper.Contrib.Extensions.Table("Department")]
public class Department
{
    public string? DeptName { get; set; }
    [Key] public int Id { get; set; }
    public int MgrId { get; set; }
    
    [Write(false)]
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}