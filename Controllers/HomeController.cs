using System.Diagnostics;
using System.Text;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using CompanyDemo.Filters;
namespace CompanyDemo.Controllers;
[FormatFilter]
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

    [HttpGet("Home/text/{privacy}")]
    public IActionResult Privacy(string privacy)
    {
        return Content(privacy);
    }
    [HttpGet]
    public IEnumerable<string> Get()
    {
        IEnumerable<string> result = new string[] { "XML", "JSON", "XML3" };
        return result;
    }
    [HttpGet]
    [Produces("application/json")]
    public IEnumerable<string> GetJson()
    {
        IEnumerable<string> result = new string[] { "JSON#", "JSON2", "JSON3" };
        return result;
    }
    [HttpGet("home/getformatfromroute/{format}")]
    public IEnumerable<string> GetFormatFromRoute(string format)
    {
        IEnumerable<string> result = new string[] { "XML#", "JSON2", "XML" };
        return result;
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