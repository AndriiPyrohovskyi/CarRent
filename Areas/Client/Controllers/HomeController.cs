using Microsoft.AspNetCore.Mvc;

namespace CarRent.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Area"] = "Client";
            ViewData["Message"] = "Кабінет клієнта";
            return View();
        }

        public IActionResult Bookings()
        {
            ViewData["Area"] = "Client";
            return View();
        }
    }
}
