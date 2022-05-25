﻿using Dapper.Contrib.Extensions;

namespace CompanyDemo.Models;

public class User
{
    [Key] 
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Role { get; set; }
}