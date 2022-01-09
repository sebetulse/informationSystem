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
    public class MufredatsController : Controller
    {
        private readonly informationSystemContext _context;

        public MufredatsController(informationSystemContext context)
        {
            _context = context;
        }

        // GET: Mufredats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mufredat.ToListAsync());
        }

        // GET: Mufredats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mufredat = await _context.Mufredat
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mufredat == null)
            {
                return NotFound();
            }

            return View(mufredat);
        }

        // GET: Mufredats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mufredats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MUFREDAT_ADI")] Mufredat mufredat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mufredat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mufredat);
        }

        // GET: Mufredats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mufredat = await _context.Mufredat.FindAsync(id);
            if (mufredat == null)
            {
                return NotFound();
            }
            return View(mufredat);
        }

        // POST: Mufredats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MUFREDAT_ADI")] Mufredat mufredat)
        {
            if (id != mufredat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mufredat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MufredatExists(mufredat.ID))
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
            return View(mufredat);
        }

        // GET: Mufredats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mufredat = await _context.Mufredat
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mufredat == null)
            {
                return NotFound();
            }

            return View(mufredat);
        }

        // POST: Mufredats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mufredat = await _context.Mufredat.FindAsync(id);
            _context.Mufredat.Remove(mufredat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MufredatExists(int id)
        {
            return _context.Mufredat.Any(e => e.ID == id);
        }
    }
}
