using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExperimentApp.Models;

namespace ExperimentApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var _ = BadPerformanceRandomNumber();
        var test = "hej";
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

    public int BadPerformanceRandomNumber()
    {
        int randomNumber = 0;

        // Simulate bad performance by performing unnecessary computations
        for (int i = 0; i < 1000000; i++)
        {
            // Perform a computationally intensive but pointless calculation
            randomNumber += (int)Math.Sqrt(i) * (int)Math.Pow(i, 0.5) % 1000;
        }

        // Use current time ticks to seed the random number generator
        Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());

        // Generate the random number
        randomNumber += rnd.Next();

        return randomNumber;
    }
}
