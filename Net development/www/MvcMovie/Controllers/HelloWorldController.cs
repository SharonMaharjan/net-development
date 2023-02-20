using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //Get:/HelloWorld/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
        
        //Get:/HelloWorld/Welcome
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;
            return View();
            //return $"Hello {name},id is:{id}";
            //return "This is the welcome action method...";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
