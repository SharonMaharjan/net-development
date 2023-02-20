using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;
using System.Data;
using System.Diagnostics;

namespace MotoGP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu()
        {
            Random rnd = new Random();
            int num = rnd.Next(1,5);
            ViewData["BannerNr"]=num;
            List<int> listOfBanner = new List<int>();
            listOfBanner.Add(1);
            listOfBanner.Add(2);
            listOfBanner.Add(3);
            ViewData["this is a list"] = listOfBanner;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}