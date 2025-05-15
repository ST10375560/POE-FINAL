using AgriEnergyConnectWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgriEnergyConnectWebApp.Controllers
{
    public class HomeController : Controller
    {
        // Injected logger instance for logging events and errors
        private readonly ILogger<HomeController> _logger;

        // Constructor that receives and assigns a logger instance
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action for the home/index page
        public IActionResult Index()
        {
            return View(); // Returns the default home view
        }

        // Action for the privacy policy page
        public IActionResult Privacy()
        {
            return View(); // Returns the privacy view
        }

        // Action for displaying error details
        // Response is not cached (Duration = 0), not stored, and not tied to any location
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Creates an error model with the current request ID (used for error tracking)
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}
