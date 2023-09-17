using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using music_albumApp.Data;
using music_albumApp.Models;

namespace music_albumApp.Controllers
{
    public class AllbumsController : Controller
    {
        private readonly music_albumAppContext _context;

        public AllbumsController(music_albumAppContext context)
        {
            _context = context;
        }

        // GET: Allbums
        public async Task<IActionResult> Index()
        {
              return _context.Allbum != null ? 
                          View(await _context.Allbum.ToListAsync()) :
                          Problem("Entity set 'music_albumAppContext.Allbum'  is null.");
        }

        // GET: Allbums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allbum == null)
            {
                return NotFound();
            }

            var allbum = await _context.Allbum
                .FirstOrDefaultAsync(m => m.id == id);
            if (allbum == null)
            {
                return NotFound();
            }

            return View(allbum);
        }

        // GET: Allbums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allbums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,AllbumTittle,Genre,Artist,AllbumIamge,Price,Description,Material")] Allbum allbum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allbum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allbum);
        }

        // GET: Allbums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allbum == null)
            {
                return NotFound();
            }

            var allbum = await _context.Allbum.FindAsync(id);
            if (allbum == null)
            {
                return NotFound();
            }
            return View(allbum);
        }

        // POST: Allbums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,AllbumTittle,Genre,Artist,AllbumIamge,Price,Description,Material")] Allbum allbum)
        {
            if (id != allbum.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allbum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllbumExists(allbum.id))
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
            return View(allbum);
        }

        // GET: Allbums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allbum == null)
            {
                return NotFound();
            }

            var allbum = await _context.Allbum
                .FirstOrDefaultAsync(m => m.id == id);
            if (allbum == null)
            {
                return NotFound();
            }

            return View(allbum);
        }

        // POST: Allbums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allbum == null)
            {
                return Problem("Entity set 'music_albumAppContext.Allbum'  is null.");
            }
            var allbum = await _context.Allbum.FindAsync(id);
            if (allbum != null)
            {
                _context.Allbum.Remove(allbum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllbumExists(int id)
        {
          return (_context.Allbum?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
