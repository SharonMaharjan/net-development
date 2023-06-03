using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPPractice.Data;
using MotoGPPractice.Models;
using MotoGPPractice.Models.ViewModels;
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
            ViewData["BannerNr"] = 2;
            var teams = _context.Teams.OrderBy(r => r.Name);
            return View(teams.ToList());
        }
        public IActionResult ListTeamsRiders()
        {
            ViewData["BannerNr"] = 2;
            var teams = _context.Teams.Include(t => t.Riders).ToList();
            return View(teams);
        }
        //public IActionResult ListTeamsRiders(int teamID = 0)
        //{
        //    ViewData["BannerNr"] = 2;
        //    var listTeamsRidersVM = new ListTeamsRidersViewModel();
        //    if (teamID != 0)
        //    {
        //        listTeamsRidersVM.Riders = _context.Riders.Where(t => t.TeamID == teamID)
        //            .OrderBy(t => t.FirstName)
        //            .ToList();
        //    }
        //    else
        //    {
        //        listTeamsRidersVM.Riders = _context.Riders.OrderBy(t => t.FirstName)
        //            .ToList();
        //    }

        //    listTeamsRidersVM.Teams = new SelectList(_context.Teams.OrderBy(t => t.Name),
        //        "TeamID", "Name");
        //    listTeamsRidersVM.TeamID = teamID;
        //    return View(listTeamsRidersVM);
        //}
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

        public IActionResult SelectRace(int raceID=0)
        {
            ViewData["BannerNr"] = 0;
            var selectRaceVM = new SelectRaceViewModel();

            if (raceID != 0)
            {
                selectRaceVM.SelectedRace = _context.Races.SingleOrDefault(r => r.RaceID == raceID);
            }

            selectRaceVM.Races = new SelectList(_context.Races.OrderBy(r => r.Name),
                                                "RaceID", "Name");
            selectRaceVM.raceID = raceID;

            return View(selectRaceVM);


        }



    }
}
