using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class DepartmentLocation
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int LocationId { get; set; }
    
    [Write(false)]
    public virtual Department Department { get; set; }
    [Write(false)]
    public virtual Location Location { get; set; }
}