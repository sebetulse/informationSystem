using informationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace informationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public ViewResult Ogrencim()
        {
            ViewData["user_id"] = HttpContext.Session.GetInt32("user_id");
            ViewData["user_kimlik_id"] = HttpContext.Session.GetInt32("user_kimlik_id");
            ViewData["user_type"] = HttpContext.Session.GetInt32("user_type");
            return View("../Ogrencis/Ogrencim");
        }
        public ViewResult Admin()
        {
            ViewData["user_id"] = HttpContext.Session.GetInt32("user_id");
            ViewData["user_kimlik_id"] = HttpContext.Session.GetInt32("user_kimlik_id");
            ViewData["user_type"] = HttpContext.Session.GetInt32("user_type");
            return View("../Admin/Index");
        }
        public IActionResult Index()
        {
            return View();
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