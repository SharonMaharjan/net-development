using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMoviePractice.Data;
using MvcMoviePractice.Models;

namespace MvcMoviePractice.Controllers
{
    public class RatingsController : Controller
    {
        private readonly MovieContext _context;
        public RatingsController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var ratings = _context.Ratings.OrderBy(r=>r.Name);
            return View(ratings.ToList());
        }

        //Get:Ratings/Create
        public IActionResult Create()
        {
            return View();
        }
        //Post
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

        //get
        public IActionResult Edit(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r=>r.RatingID==id);
            return View(rating);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("RatingID,Code,Name")]Rating rating)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(rating);
                    _context.Ratings.Attach(rating);
                    _context.Entry(rating).Property(r=>r.Code).IsModified=true;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException) {
                    throw;
                }
                return RedirectToAction("List");
            }
            return View(rating);
        }

        //get
        public IActionResult Delete(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
