using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using księgarnia_Xardas.Data;
using księgarnia_Xardas.Models;

namespace księgarnia_Xardas.Controllers
{
    [Authorize]
    public class RandomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandomController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var randomBook = _context.Books.OrderBy(r => Guid.NewGuid()).FirstOrDefault();

            return View(randomBook);
        }
    }
}
