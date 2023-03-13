using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Areas.Admin.Controllers
{
    public class MaintainController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles="Authorization")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
