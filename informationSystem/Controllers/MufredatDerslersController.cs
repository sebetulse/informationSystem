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
    public class MufredatDerslersController : Controller
    {
        private readonly informationSystemContext _context;

        public MufredatDerslersController(informationSystemContext context)
        {
            _context = context;
        }

        // GET: MufredatDerslers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mufredat_Dersler.ToListAsync());
        }

        // GET: MufredatDerslers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mufredatDersler = await _context.Mufredat_Dersler
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mufredatDersler == null)
            {
                return NotFound();
            }

            return View(mufredatDersler);
        }

        // GET: MufredatDerslers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MufredatDerslers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MUFREDAT_ID,DERS_ID")] MufredatDersler mufredatDersler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mufredatDersler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mufredatDersler);
        }

        // GET: MufredatDerslers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mufredatDersler = await _context.Mufredat_Dersler.FindAsync(id);
            if (mufredatDersler == null)
            {
                return NotFound();
            }
            return View(mufredatDersler);
        }

        // POST: MufredatDerslers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MUFREDAT_ID,DERS_ID")] MufredatDersler mufredatDersler)
        {
            if (id != mufredatDersler.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mufredatDersler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MufredatDerslerExists(mufredatDersler.ID))
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
            return View(mufredatDersler);
        }

        // GET: MufredatDerslers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mufredatDersler = await _context.Mufredat_Dersler
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mufredatDersler == null)
            {
                return NotFound();
            }

            return View(mufredatDersler);
        }

        // POST: MufredatDerslers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mufredatDersler = await _context.Mufredat_Dersler.FindAsync(id);
            _context.Mufredat_Dersler.Remove(mufredatDersler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MufredatDerslerExists(int id)
        {
            return _context.Mufredat_Dersler.Any(e => e.ID == id);
        }
    }
}
