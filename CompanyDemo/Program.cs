using System.Security.Claims;
using System.Text;
using AspNetCore.Identity.Dapper;
using CompanyDemo;
using CompanyDemo.Abstract;
using CompanyDemo.Data;
using CompanyDemo.Extensions;
using CompanyDemo.Filters;
using CompanyDemo.Interfaces;
using CompanyDemo.Repository;
using CompanyDemo.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDapperStores(options => {
        options.AddRolesTable<ExtendedRolesTable, ExtendedIdentityRole>();
    })
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddSingleton<BrowserProperties>();
//builder.Services.AddTransient<IDbConnectionFactory, SqlServerDbConnectionFactory>();
builder.Services.AddTransient<IUserProfilesTable, UserProfilesTable>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositoryContrib>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomResourceFilter>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();