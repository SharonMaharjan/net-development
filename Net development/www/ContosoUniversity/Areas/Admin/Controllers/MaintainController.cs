using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Areas.Admin.Controllers
{
    public class MaintainController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
