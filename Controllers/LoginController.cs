using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CompanyDemo.Controllers;

public class LoginController:Controller
{
    private readonly IUserRepository _userRepository;
    
    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public IActionResult Authenticate(User model)
    {
        var user = _userRepository.Find(model.Email, model.Password);

        if (user == null)
            return NotFound(new { message = "User not found" });

        var token = TokenService.GenerateToken(user);

        user.Password = "";

        return View();
    }

    public IActionResult Authenticate()
    {
        return View();
    }
}