using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TsukuyomiMuseum.Database;
using TsukuyomiMuseum.Models;

namespace TsukuyomiMuseum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            using (MuseumContext db = new MuseumContext())
            {
                List<Publication> productList = db.Publications.ToList();
                return View("Gallery", productList);
            }
        }

        public IActionResult Events()
        {
            using (MuseumContext db = new MuseumContext())
            {
                List<Event> productList = db.Events.ToList();
                return View("Events", productList);
            }
        }

        public IActionResult Shoop()
        {
            using (MuseumContext db = new MuseumContext())
            {
                List<Product> productList = db.Products.ToList();
                return View("Shoop", productList);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}