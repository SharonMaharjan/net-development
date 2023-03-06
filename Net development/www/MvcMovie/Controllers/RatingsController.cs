using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {


        private readonly MovieContext _context;

        public RatingsController(MovieContext context)
        {
            _context = context;
        }

        //Get :Ratings/Create
        public IActionResult Create()
        {
            return View();
        }
        //Post :Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(rating);
        }


        public IActionResult List()
        {
            var ratings = _context.Ratings.OrderBy(r => r.Name);
            return View(ratings.ToList());
        }
        //Get:Rating/Edit
        public IActionResult Edit(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            return View(rating);
        }

        //POST: Ratings/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("RatingID,Code,Name")] Rating rating)
            {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("List");
            }
            return View(rating);
            }

        //Get:Ratings/Delete
        public IActionResult Delete(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r=>r.RatingID==id);
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
