using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityPractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrator")]
    public class MaintainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
