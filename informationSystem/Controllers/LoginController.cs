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
            var kimlik = await _context.KIMLIK.FirstAsync(m => m.ID == kullanici.KIMLIK_ID);
            var iletisim = await _context.ILETISIM.FirstAsync(m => m.ID == kimlik.ILETISIM_ID);

            HttpContext.Session.SetInt32("user_id", kullanici.ID);
            HttpContext.Session.SetInt32("user_kimlik_id", (int)kullanici.KIMLIK_ID);
            HttpContext.Session.SetInt32("user_type", kullanici.TUR? 1:0);
            HttpContext.Session.SetInt32("kimlik_id", kimlik.ID);
            HttpContext.Session.SetInt32("iletisim_id", iletisim.ID);

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
