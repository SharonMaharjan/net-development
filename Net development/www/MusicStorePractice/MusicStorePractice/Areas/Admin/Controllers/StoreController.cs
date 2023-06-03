using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStorePractice.Data;

namespace MusicStorePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListGenres()
        {
            var genres = _context.Genres.OrderBy(g => g.Name);
            return View(genres.ToList());
        }
        public IActionResult ListAlbums(int genreId)
        {
            var genres = _context.Genres.FirstOrDefault(g=>g.GenreID==genreId);
            var albums = _context.Albums.Where(a => a.GenreID == genreId).OrderBy(a => a.Title).ToList();
            ViewBag.GenresName = genres?.Name;
            return View(albums);
        }

        public IActionResult Details(int id)
        {
            var album = _context.Albums.Include(a => a.Artist).Include(a => a.Genre).FirstOrDefault(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
    }
}
