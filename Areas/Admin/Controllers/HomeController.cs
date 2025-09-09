using Microsoft.AspNetCore.Mvc;

namespace CarRent.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Area"] = "Admin";
            ViewData["Message"] = "Панель адміністратора";
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewData["Area"] = "Admin";
            return View();
        }
    }
}