using Microsoft.AspNetCore.Mvc;
using MiddlewareTask.Models;

namespace MiddlewareTask.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FromForm()
        {
            return View();
        }
    }
}
