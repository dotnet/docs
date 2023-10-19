using System.Diagnostics;
using AspNetCore.Mvc.Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.Example.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogIndex();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

static partial class Log
{
    [LoggerMessage(Level = LogLevel.Information, Message = "Running Index() function")]
    public static partial void LogIndex(this ILogger logger);
}
