using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.DAL;
//using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.ViewModels;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
	public class MoviesController : Controller
	{
		private IRepository<Movie> movieRepository;
		private IRepository<Rating> ratingRepository;

		public MoviesController(IRepository<Movie> movieRepository,IRepository<Rating> ratingRepository)
		{
			this.movieRepository = movieRepository;
			this.ratingRepository = ratingRepository;

            
		}

		//public MoviesController(MovieContext context)
		//{
  //          movieRepository = new GenericRepository<Movie>(context);
		//	ratingRepository = new GenericRepository<Rating>(context);

		//}

		public IActionResult List(int ratingID = 0)
		{
			var listMoviesVM = new ListMoviesViewModel();

			if (ratingID != 0)
			{
			listMoviesVM.Movies = movieRepository.Get(
				filter: m => m.RatingID == ratingID,
				orderBy: m => m.OrderBy(m => m.Title)).ToList();
					
			
			}
			else
			{
				listMoviesVM.Movies = movieRepository.Get(
					orderBy: m=>m.OrderBy(x => x.Title)).ToList();
			}

			listMoviesVM.Ratings =
				new SelectList(ratingRepository.Get(
					
					orderBy: m=>m.OrderBy(x => x.Name)).ToList(),
					"RatingID", "Name");
					
							
			listMoviesVM.ratingID = ratingID;

			return View(listMoviesVM);
		}

		public IActionResult Details(int id)
		{
			//var movie = _context.Movies
							//.Include(m => m.Rating)
							//.SingleOrDefault(m => m.MovieID == id);
			var movie = movieRepository.Get(
				filter: x => x.MovieID == id,
				includes:x => x.Rating).FirstOrDefault();
				
			return View(movie);
		}

		// GET: Movies/Create
		public IActionResult Create()
		{
			ViewData["Ratings"] =
				new SelectList(ratingRepository.GetAll().OrderBy(r => r.Name),
							   "RatingID",
							   "Name");

			return View();
		}

		// POST: Movies/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("RatingID,Name")] Rating rating)
		{
			if (ModelState.IsValid)
			{
				ratingRepository.Insert(rating);
				ratingRepository.Save();
				return RedirectToAction("List");
			}
			return View(rating);
		}

	}
}