using Microsoft.AspNetCore.Mvc;
using MvcMoviePractice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMoviePractice.Models.ViewModels;

namespace MvcMoviePractice.Controllers
{
    public class MoviesController : Controller
    {
        public readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult List(int ratingID=0)
        {
            var listMoviesVM = new ListMoviesViewModel();
            if (ratingID != 0)
            {
                listMoviesVM.Movies= _context.Movies.Where(m=>m.RatingID==ratingID).OrderBy(m=>m.Title).ToList();
            }
            else
            {
                listMoviesVM.Movies=_context.Movies.OrderBy(m => m.Title).ToList();
            }
            listMoviesVM.Ratings =
                new SelectList(_context.Ratings.OrderBy(r => r.Name),
                "RatingID", "Name");
            return View(listMoviesVM);
           
        }

        //get
        public IActionResult Create()
        {
            ViewData["Ratings"] = new SelectList(_context.Ratings.OrderBy(r => r.Name), "RatingID", "Name");
            return View();
        }
        public IActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Rating)
                .SingleOrDefault(m => m.MovieID == id);
            return View(movies);
        }
    }
}
