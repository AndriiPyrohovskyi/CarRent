using Microsoft.AspNetCore.Mvc;

namespace CarRent.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Area"] = "Manager";
            ViewData["Message"] = "Панель менеджера";
            return View();
        }

        public IActionResult Orders()
        {
            ViewData["Area"] = "Manager";
            return View();
        }
    }
}