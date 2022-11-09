using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCegMVC1.Data;
using WebCegMVC1.Models;

namespace WebCegMVC1.Controllers
{
    public class EFMunkatarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EFMunkatarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EFMunkatars
        public async Task<IActionResult> Index()
        {
              return View(await _context.modellMunkatars.ToListAsync());
        }

        // GET: EFMunkatars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.modellMunkatars == null)
            {
                return NotFound();
            }

            var modellMunkatars = await _context.modellMunkatars
                .FirstOrDefaultAsync(m => m.id == id);
            if (modellMunkatars == null)
            {
                return NotFound();
            }

            return View(modellMunkatars);
        }

        // GET: EFMunkatars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EFMunkatars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nev,varos,beosztas,nyelvtudas")] modellMunkatars modellMunkatars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modellMunkatars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modellMunkatars);
        }

        // GET: EFMunkatars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.modellMunkatars == null)
            {
                return NotFound();
            }

            var modellMunkatars = await _context.modellMunkatars.FindAsync(id);
            if (modellMunkatars == null)
            {
                return NotFound();
            }
            return View(modellMunkatars);
        }

        // POST: EFMunkatars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nev,varos,beosztas,nyelvtudas")] modellMunkatars modellMunkatars)
        {
            if (id != modellMunkatars.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modellMunkatars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!modellMunkatarsExists(modellMunkatars.id))
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
            return View(modellMunkatars);
        }

        // GET: EFMunkatars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.modellMunkatars == null)
            {
                return NotFound();
            }

            var modellMunkatars = await _context.modellMunkatars
                .FirstOrDefaultAsync(m => m.id == id);
            if (modellMunkatars == null)
            {
                return NotFound();
            }

            return View(modellMunkatars);
        }

        // POST: EFMunkatars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.modellMunkatars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.modellMunkatars'  is null.");
            }
            var modellMunkatars = await _context.modellMunkatars.FindAsync(id);
            if (modellMunkatars != null)
            {
                _context.modellMunkatars.Remove(modellMunkatars);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool modellMunkatarsExists(int id)
        {
          return _context.modellMunkatars.Any(e => e.id == id);
        }
    }
}
