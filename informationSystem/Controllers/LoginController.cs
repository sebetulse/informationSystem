using Microsoft.EntityFrameworkCore;
using informationSystem.Data;
using informationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace informationSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly informationSystemContext _context;

        public LoginController(informationSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> check(string KULLANICI_ADI, string  SIFRE)
        {
            var kullanici = await _context.KULLANICILAR.FirstAsync(m =>  m.KULLANICI_ADI == KULLANICI_ADI && m.SIFRE == SIFRE);

            if (kullanici == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("user_id", kullanici.ID);
            HttpContext.Session.SetInt32("user_kimlik_id", (int)kullanici.KIMLIK_ID);
            HttpContext.Session.SetInt32("user_type", kullanici.TUR? 1:0);
            if (kullanici.TUR)
            {
                return RedirectToAction("Ogrencim", "Home");//ilk parametre function(action),ikinci parametre controller ismi
                
                
            } else
            {
                return RedirectToAction("Admin", "Home");
            }

           
        }


        private bool KullaniciExists(int id)
        {
            return _context.KULLANICILAR.Any(e => e.ID == id);
        }
    }
}
