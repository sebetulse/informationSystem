#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using informationSystem.Data;
using informationSystem.Models;

namespace informationSystem.Controllers
{
    public class KimliksController : Controller
    {
        private readonly informationSystemContext _context;

        public KimliksController(informationSystemContext context)
        {
            _context = context;
        }

        // GET: Kimliks
        public async Task<IActionResult> Index()
        {
            return View(await _context.KIMLIK.ToListAsync());
        }

        // GET: Kimliks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kimlik = await _context.KIMLIK
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kimlik == null)
            {
                return NotFound();
            }

            return View(kimlik);
        }

        // GET: Kimliks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kimliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TC_NO,AD,SOYAD,DOGUM_YERI,DOGUM_TARIHI,ILETISIM_ID")] Kimlik kimlik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kimlik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kimlik);
        }

        // GET: Kimliks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kimlik = await _context.KIMLIK.FindAsync(id);
            if (kimlik == null)
            {
                return NotFound();
            }
            return View(kimlik);
        }

        // POST: Kimliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TC_NO,AD,SOYAD,DOGUM_YERI,DOGUM_TARIHI,ILETISIM_ID")] Kimlik kimlik)
        {
            if (id != kimlik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kimlik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KimlikExists(kimlik.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kimlik);
        }

        // GET: Kimliks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kimlik = await _context.KIMLIK
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kimlik == null)
            {
                return NotFound();
            }

            return View(kimlik);
        }

        // POST: Kimliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kimlik = await _context.KIMLIK.FindAsync(id);
            _context.KIMLIK.Remove(kimlik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KimlikExists(int id)
        {
            return _context.KIMLIK.Any(e => e.ID == id);
        }
    }
}
