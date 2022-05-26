using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class User
{
    [Key] 
    public int Id { get; set; }
    public string Email { get; set; }
    public string? Role { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime TokenCreated { get; set; }
    public DateTime TokenExpires { get; set; }
}