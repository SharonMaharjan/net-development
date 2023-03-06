using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
