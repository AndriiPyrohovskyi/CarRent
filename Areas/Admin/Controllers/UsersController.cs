using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;

namespace CarRent.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly CarRentContext _context;

        // Dependency Injection - отримуємо доступ до БД
        public UsersController(CarRentContext context)
        {
            _context = context;
        }

        // GET: Admin/Users - показати всіх користувачів
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // GET: Admin/Users/Details/5 - показати деталі користувача
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // GET: Admin/Users/Create - форма для створення нового користувача
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create - обробка створення користувача
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
