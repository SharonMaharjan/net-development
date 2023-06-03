using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusicStorePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Administrator")]
    public class AlbumsController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }
    }
}
