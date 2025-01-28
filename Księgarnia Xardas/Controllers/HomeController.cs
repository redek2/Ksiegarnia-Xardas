using System.Diagnostics;
using Księgarnia_Xardas.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Księgarnia_Xardas.Controllers
{
    public class HomeController : Controller
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        public IActionResult Index()
        {
            Logger.Info("Witamy na stronie głównej"); // NLog do logowania zdarzeń
            return View();
        }

        public IActionResult Privacy()
        {
            Logger.Info("Otworzono stronę prywatności.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Logger.Error("Wystąpił błąd na stronie.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}