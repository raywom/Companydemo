// using Dapper.Contrib.Extensions;
// using Microsoft.EntityFrameworkCore;
//
// namespace CompanyDemo.Models;
//
// [PrimaryKey("Id")]
// public class EmployeeProject
// {
//     [Key]
//     public int Id { get; set; }
//     
//     
//     
//     public int EmployeeId { get; set; }
//     public int ProjectId { get; set; }
//     
//     [Write(false)]
//     public virtual Project Project { get; set; }
//     [Write(false)]
//     public virtual Employee Employee { get; set; }
// }