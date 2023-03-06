using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Areas.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Administrator")]
    public class AlbumController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
