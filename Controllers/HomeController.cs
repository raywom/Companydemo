using System.Diagnostics;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using CompanyDemo.Filters;
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
        // if (BrowserProperties.IsGoodBrowser(HttpContext.Request))
        // {
        //     return View();
        // }

        //return RedirectToAction("ErrorUnsupportedBrowser");

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

public class ErrorUnsupportedBrowser
{
}