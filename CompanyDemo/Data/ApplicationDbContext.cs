using CompanyDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDemo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Department> Department { get; set; }
    public DbSet<Employee> Employee { get; set; }
    //public DbSet<EmployeeProject> EmployeeProject { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Department>().Ignore(t => t.Employees);


        //Adding as a foreign key
        modelBuilder.Entity<Employee>()
            .HasOne(c => c.Department).WithMany(e => e.Employees)
            .HasForeignKey(c => c.Id);
        
       // Adding as a foreign key
         // modelBuilder.Entity<EmployeeProject>().ToTable("EmployeeProject")
         //     .HasOne(c => c.Employee).WithMany(e => e.EmployeeProjects)
         //     .HasForeignKey(c => c.EmployeeId);
         //
         // //Adding as a foreign key
         // modelBuilder.Entity<EmployeeProject>().ToTable("EmployeeProject")
         //     .HasOne(c => c.Project).WithMany(e => e.EmployeeProjects)
         //     .HasForeignKey(c => c.ProjectId);
         //
    }
}