using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;

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
        public IActionResult Create([Bind("RatingID,Code,Name")]RatingsController rating)
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
    }
}
