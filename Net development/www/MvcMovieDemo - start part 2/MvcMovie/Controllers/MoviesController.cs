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
		private IUnitOfWork _uow;

		//private IRepository<Movie> movieRepository;
		//private IRepository<Rating> ratingRepository;

		public MoviesController(IUnitOfWork uow)
		{
			_uow = uow;
		}
		//public MoviesController(IRepository<Movie> movieRepository,IRepository<Rating> ratingRepository)
		//{
		//	this.movieRepository = movieRepository;
		//	this.ratingRepository = ratingRepository;


		//}

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
			listMoviesVM.Movies = _uow.MovieRepository.Get(
				filter: m => m.RatingID == ratingID,
				orderBy: m => m.OrderBy(m => m.Title)).ToList();
					
			
			}
			else
			{
				listMoviesVM.Movies = _uow.MovieRepository.Get(
					orderBy: m=>m.OrderBy(x => x.Title)).ToList();
			}

			listMoviesVM.Ratings =
				new SelectList(_uow.RatingRepository.Get(
					
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
			var movie = _uow.MovieRepository.Get(
				filter: x => x.MovieID == id,
				includes:x => x.Rating).FirstOrDefault();
				
			return View(movie);
		}

		// GET: Movies/Create
		public IActionResult Create()
		{
			ViewData["Ratings"] =
				new SelectList(_uow.RatingRepository.GetAll().OrderBy(r => r.Name),
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
				_uow.RatingRepository.Insert(rating);
				_uow.Save();
				return RedirectToAction("List");
			}
			return View(rating);
		}

		//Get: Movies/Add

		public IActionResult Add()
        {
			var addMovieVM = new AddMovieViewModel();
			addMovieVM.Movie = new Movie();


			return View(addMovieVM);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add([Bind("Movie,Code,Name")]AddMovieViewModel model)
        {
            try
            {
				if(ModelState.IsValid)
                {
					var rating = _uow.RatingRepository.Get
						(filter:r => r.Code==model.Code && r.Name == model.Name).FirstOrDefault();

					if (rating == null)
                    {
						rating = new Rating { Code = model.Code,Name = model.Name };
						_uow.RatingRepository.Insert(rating);
                    }
					model.Movie.Rating = rating;

					_uow.MovieRepository.Insert(model.Movie);
					_uow.Save();
                }
            }
        }
	}
}