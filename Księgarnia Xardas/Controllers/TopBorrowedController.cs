using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using księgarnia_Xardas.Data;
using księgarnia_Xardas.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace księgarnia_Xardas.Controllers
{
    [Authorize]
    public class TopBorrowedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopBorrowedController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var topBorrowedBooks = _context.Borrows
                .GroupBy(b => b.Book)
                .Select(group => new TopBorrowedBook
                {
                    Title = group.Key.Title,
                    Author = group.Key.Author,
                    BorrowCount = group.Count(),
                    Rank = 0 // placeholder, ranking będzie nadany później
                })
                .OrderByDescending(b => b.BorrowCount)
                .Take(3)
                .ToList();

            // Przydziel rangę
            for (int i = 0; i < topBorrowedBooks.Count; i++)
            {
                topBorrowedBooks[i].Rank = i + 1;
            }

            // Posortowanie książek według rangi
            topBorrowedBooks = topBorrowedBooks.OrderBy(b => b.Rank).ToList();

            return View(topBorrowedBooks);
        }
    }
}