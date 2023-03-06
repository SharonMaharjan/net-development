using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Areas.Controllers
{
    [Area("Admin")]
    public class AlbumController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
