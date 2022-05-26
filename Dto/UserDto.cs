using Dapper.Contrib.Extensions;

namespace CompanyDemo.Dto;

public class UserDto
{
    [Key] 
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}