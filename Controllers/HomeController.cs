using System.Diagnostics;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using CompanyDemo.Filters;
using CompanyDemo.Interfaces;
using CompanyDemo.Stores;
using CompanyDemo.Tables;
using CompanyDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CompanyDemo.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [CustomResourceFilter]
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        
        foreach(var claim in User.Claims)
        {
            Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value: {claim.Value}");
        }
        if(User.IsInRole("Admin"))
            return View();
        else
        {
            return RedirectToAction("Index");
        }
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