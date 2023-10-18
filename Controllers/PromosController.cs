using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DE_TallerTabla2.Data;
using DE_TallerTabla2.Models;

namespace DE_TallerTabla2.Controllers
{
    public class PromosController : Controller
    {
        private readonly DE_TallerTabla2Context _context;

        public PromosController(DE_TallerTabla2Context context)
        {
            _context = context;
        }

        // GET: Promos
        public async Task<IActionResult> Index()
        {
              return _context.Promos != null ? 
                          View(await _context.Promos.ToListAsync()) :
                          Problem("Entity set 'DE_TallerTabla2Context.Promos'  is null.");
        }

        // GET: Promos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promos == null)
            {
                return NotFound();
            }

            var promo = await _context.Promos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoId,PromoName,PromoDescription,Id")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promo);
        }

        // GET: Promos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promos == null)
            {
                return NotFound();
            }

            var promo = await _context.Promos.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            return View(promo);
        }

        // POST: Promos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoId,PromoName,PromoDescription,Id")] Promo promo)
        {
            if (id != promo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.Id))
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
            return View(promo);
        }

        // GET: Promos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promos == null)
            {
                return NotFound();
            }

            var promo = await _context.Promos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promos == null)
            {
                return Problem("Entity set 'DE_TallerTabla2Context.Promos'  is null.");
            }
            var promo = await _context.Promos.FindAsync(id);
            if (promo != null)
            {
                _context.Promos.Remove(promo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
          return (_context.Promos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
