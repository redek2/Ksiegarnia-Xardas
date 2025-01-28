using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using księgarnia_Xardas.Data;
using księgarnia_Xardas.Models;

namespace księgarnia_Xardas.Controllers
{
    [Authorize]
    public class BorrowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display all books borrowed by the logged-in user
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name; // Replace with appropriate User ID logic if needed
            var borrows = await _context.Borrows
                .Include(b => b.Book)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BorrowDate)
                .ToListAsync();

            return View(borrows);
        }

        // Handle book return action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id)
        {
            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (borrow == null || borrow.ReturnDate != null)
            {
                return NotFound(); // Borrow record not found or book already returned
            }

            borrow.ReturnDate = DateTime.Now;
            borrow.Book.CopiesAvailable++; // Increment the available copies count

            _context.Borrows.Update(borrow);
            _context.Books.Update(borrow.Book);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirect back to the My Borrows page
        }
    }
}
