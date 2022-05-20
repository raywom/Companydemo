using CompanyDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDemo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Department>().Ignore(t => t.Employees);


        //Adding as a foreign key
        modelBuilder.Entity<Employee>()
            .HasOne(c => c.department).WithMany(e => e.Employees)
            .HasForeignKey(c => c.Id);
    }
}