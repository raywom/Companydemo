using System.Diagnostics;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using CompanyDemo.Filters;
using CompanyDemo.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CompanyDemo.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepository;
    
    public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }
    
    [CustomResourceFilter]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }


    public IActionResult ErrorUnsupportedBrowser()
    {
        return View(new ErrorUnsupportedBrowser());
    }
}