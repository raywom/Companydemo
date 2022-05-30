using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Identity;

namespace CompanyDemo.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}