using Microsoft.AspNetCore.Mvc;

namespace MvcMoviePractice.Controllers
{
    public class HelloWorldController : Controller
    {
        //get method of hello world
        public IActionResult Index()
        {
            return View();
        }

        //get method of hello world welcome
        public IActionResult Welcome(string name, int numTimes=3)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
