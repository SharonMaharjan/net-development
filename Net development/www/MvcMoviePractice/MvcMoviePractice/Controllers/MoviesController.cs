using Microsoft.AspNetCore.Mvc;
using MvcMoviePractice.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcMoviePractice.Controllers
{
    public class MoviesController : Controller
    {
        public readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var movies = _context.Movies.OrderBy(m => m.Title);
            return View(movies.ToList());
        }

        public IActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Rating)
                .SingleOrDefault(m => m.MovieID == id);
            return View(movies);
        }
    }
}
