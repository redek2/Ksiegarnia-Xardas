using księgarnia_Xardas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ReportsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Akcja do wyświetlania raportu aktywności użytkowników
    public IActionResult UserActivity()
    {
        var reports = _context.Users
            .Select(user => new UserActivityReport
            {
                UserId = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                BorrowCount = _context.Borrows.Count(b => b.UserId == user.Email && b.ReturnDate == null),
                ReturnCount = _context.Borrows.Count(b => b.UserId == user.Email && b.ReturnDate != null)
            }).ToList();

        return View(reports);
    }

    // Akcja do wyświetlania raportu rejestracji użytkowników
    public IActionResult UserRegistration()
    {
        var reports = _context.Users
            .Select(user => new UserRegistrationReport
            {
                UserId = user.Id,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber
            }).ToList();
        return View(reports);
    }

    // Akcja do wyświetlania raportu wypożyczeń użytkowników
    public IActionResult UserBorrowing()
    {
        var reports = (from borrow in _context.Borrows
                       join book in _context.Books on borrow.BookId equals book.Id
                       select new UserBorrowingReport
                       {
                           UserId = borrow.UserId,
                           Title = book.Title,
                           BorrowDate = borrow.BorrowDate,
                           ReturnDate = borrow.ReturnDate,
                           DateDue = borrow.DateDue
                       }).ToList();

        return View(reports);
    }
}
