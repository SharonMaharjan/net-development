using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoGPPractice.Data;
using MotoGPPractice.Models;
using System.Xml.Linq;

namespace MotoGPPractice.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;
        
        public InfoController(GPContext context)
        {
            _context = context;
        }
        public IActionResult ListRaces()
        {
            ViewData["BannerNr"] = 0;
            var races = _context.Races.OrderBy(r=>r.Date);
            return View(races.ToList());
        }
        public IActionResult ListTeams()
        {
            return View();
        }
        public IActionResult ListRiders(int id)
        {
            ViewData["BannerNr"] = 1;
            //var riders = _context.Riders
            //        .Include(r => r.Country)
            //        .SingleOrDefault(r => r.RiderID == id);

            var riders = _context.Riders.OrderBy(r => r.Number);

            return View(riders.ToList());
        }

        public IActionResult BuildMap()
        {
            ViewData["BannerNr"] = 0;
            var races = _context.Races.OrderBy(r=> r.Name);
            //var races = new List<Race>() {
            //new Race(){ RaceID = 1, X = 517, Y = 19, Name = "Assen" },
            //new Race(){ RaceID = 2, X = 859, Y = 249, Name = "Losail Circuit" },
            //new Race(){ RaceID = 3, X = 194, Y = 428, Name = "Autódromo Termas de Río Hondo" }
            //};
            return View(races.ToList());
        }
        public IActionResult ShowRace(int id) 
        {
            ViewData["BannerNr"] = 0;
            var race = _context.Races.FirstOrDefault(r=>r.RaceID==id);
            var raceList = new List<Race> { race };
            return View(raceList); 
        }
    }
}
