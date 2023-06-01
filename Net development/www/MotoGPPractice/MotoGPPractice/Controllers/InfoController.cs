using Microsoft.AspNetCore.Mvc;
using MotoGPPractice.Models;
using System.Xml.Linq;

namespace MotoGPPractice.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult ListRaces()
        {
            ViewData["BannerNr"] = 0;
            return View();
        }
        public IActionResult ListTeams()
        {
            return View();
        }
        public IActionResult ListRiders()
        {
            return View();
        }

        public IActionResult BuildMap()
        {
            ViewData["BannerNr"] = 0;
            var races = new List<Race>() {
            new Race(){ RaceID = 1, X = 517, Y = 19, Name = "Assen" },
            new Race(){ RaceID = 2, X = 859, Y = 249, Name = "Losail Circuit" },
            new Race(){ RaceID = 3, X = 194, Y = 428, Name = "Autódromo Termas de Río Hondo" }
            };
            return View(races);
        }
        public IActionResult ShowRace(int id) {
          
            return View(); }
    }
}
