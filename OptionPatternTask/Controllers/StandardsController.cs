using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OptionPatternTask;
using OptionPatternTask.Models;

namespace OptionPatternTask.Controllers
{
    public class StandardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StandardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Standards
        public async Task<IActionResult> Index()
        {
              return _context.Standards != null ? 
                          View(await _context.Standards.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Standards'  is null.");
        }

        // GET: Standards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Standards == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards
                .FirstOrDefaultAsync(m => m.StandardId == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        // GET: Standards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Standards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Standard standard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standard);
        }

        // GET: Standards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Standards == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards.FindAsync(id);
            if (standard == null)
            {
                return NotFound();
            }
            return View(standard);
        }

        // POST: Standards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StandardId,StandardName")] Standard standard)
        {
            if (id != standard.StandardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandardExists(standard.StandardId))
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
            return View(standard);
        }

        // GET: Standards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Standards == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards
                .FirstOrDefaultAsync(m => m.StandardId == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        // POST: Standards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Standards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Standards'  is null.");
            }
            var standard = await _context.Standards.FindAsync(id);
            if (standard != null)
            {
                _context.Standards.Remove(standard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandardExists(int id)
        {
          return (_context.Standards?.Any(e => e.StandardId == id)).GetValueOrDefault();
        }
    }
}
