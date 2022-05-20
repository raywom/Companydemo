using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class EmployeeProject
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    
    [Write(false)]
    public virtual Project Project { get; set; }
    [Write(false)]
    public virtual Employee Employee { get; set; }
}