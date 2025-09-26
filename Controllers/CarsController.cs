using Microsoft.AspNetCore.Mvc;
using CarRent.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    /// <summary>
    /// ПРОСТИЙ ПРИКЛАД: Контролер автомобілів без зайвих ускладнень
    /// </summary>
    public class CarsController : Controller
    {
        private readonly CarRentContext _context;

        public CarsController(CarRentContext context)
        {
            _context = context;
        }

        // GET: /Cars - показати всі автомобілі
        public async Task<IActionResult> Index()
        {
            // 📝 Просто беремо дані з БД і показуємо
            var cars = await _context.Cars.ToListAsync();
            return View(cars);
        }

        // GET: /Cars/Details/5 - деталі конкретного авто
        public async Task<IActionResult> Details(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            
            if (car == null)
                return NotFound();
                
            return View(car);
        }

        // GET: /Cars/Available - тільки доступні авто
        public async Task<IActionResult> Available()
        {
            var availableCars = await _context.Cars
                .Where(c => c.IsAvailable)
                .OrderBy(c => c.PricePerDay)
                .ToListAsync();
                
            return View(availableCars);
        }
    }
}

/* 
🎯 ЯК ЦЕ ПРАЦЮЄ:

1. Користувач заходить на /Cars
2. Контролер викликає Index()
3. Index() бере дані з бази через _context
4. Передає дані в View
5. View (файл Views/Cars/Index.cshtml) показує HTML

✅ ПРОСТО і ЗРОЗУМІЛО для навчання!

❌ Для ПРОДАКШЕНУ треба:
- Services (бізнес-логіка)
- ViewModels (адаптація даних для UI)  
- Areas (розподіл по ролям)
- Validation (перевірка даних)
- Authentication (хто увійшов)
- Authorization (що дозволено)
*/
