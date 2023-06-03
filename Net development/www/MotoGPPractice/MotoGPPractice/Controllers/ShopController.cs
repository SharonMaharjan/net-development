using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPPractice.Data;
using MotoGPPractice.Models;
using MotoGPPractice.Models.ViewModels;

namespace MotoGPPractice.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext _context;

        public ShopController(GPContext context)
        {
            _context = context;
        }
        //get
        public IActionResult OrderTicket()
        {
            ViewData["BannerNr"] = 3;
            ViewData["Tickets"] = new SelectList(_context.Tickets.OrderBy(t => t.Number),
                "TicketID", "Number");
            ViewData["Countries"] = 
                new SelectList(_context.Countries.OrderBy(c => c.Name),
         "CountryID", "Name");
            ViewData["Races"] = 
                new SelectList(_context.Races.OrderBy(r => r.Name),
                "RaceID", "Name");
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderTicket([Bind("TicketID,Name,Email,Address,CountryID,RaceID,Number,OrderDate,Paid")] Ticket ticket)
        {
            ViewData["BannerNr"] = 3;
            if (ModelState.IsValid)
            {
                ticket.CountryID = 1;
                ticket.RaceID = 1;
                ticket.Number = 1;
                ticket.OrderDate = DateTime.Now;
                ticket.Paid = false;

                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder");
            }
            return View(ticket);
        }
        public IActionResult ConfirmOrder() {
            ViewData["BannerNr"] = 3;
            return View();
        }

        public IActionResult ListTickets(int raceID=0)
        {
            ViewData["BannerNr"] = 3;
            var listTicketsVM = new ListTicketsViewModel();
            if (raceID != 0)
            {
                listTicketsVM.Tickets =  _context.Tickets.Where(t=>t.RaceID== raceID).
                    OrderBy(t => t.OrderDate).ToList();
            }
            else
            {
                listTicketsVM.Tickets =  _context.Tickets.OrderBy(t => t.OrderDate).ToList();
            }

            if (listTicketsVM.Tickets.Count == 0)
            {
                ViewData["NoTicketsMessage"] = "No tickets ordered for this race yet.";
            }
            listTicketsVM.Races =
                new SelectList(_context.Races.OrderBy(r => r.Name),
                "RaceID", "Name");
            listTicketsVM.raceID = raceID;
            listTicketsVM.CountryNames = _context.Countries.ToDictionary(c => c.CountryID, c => c.Name);
            listTicketsVM.RaceIDs = _context.Races.ToDictionary(r => r.RaceID, r => r.Name);
            return View(listTicketsVM);
            //var ordertickets = _context.Tickets.OrderBy(o=>o.OrderDate);
            //return View(ordertickets.ToList());
        }

        //get
        public IActionResult EditTicket(int id)
        {
            ViewData["BannerNr"] = 3;
            var ticket = _context.Tickets.Include(t => t.Country).Include(t => t.Race).SingleOrDefault(r=>r.TicketID==id);
            return View(ticket);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(int id,
            [Bind("TicketID","Paid")]Ticket ticket)
        {
            ViewData["BannerNr"] = 3;
            if (ModelState.IsValid)
            {
                try
                {
                    var existingTicket = _context.Tickets.SingleOrDefault(r => r.TicketID == id);
                    if (existingTicket != null)
                    {
                        existingTicket.Paid = ticket.Paid;
                        _context.Update(existingTicket);
                        _context.SaveChanges();

                    }
                }
                catch
                {
                    throw;
                }
                return RedirectToAction("ListTickets");
            }
            return View(ticket);
        }
    }
}
