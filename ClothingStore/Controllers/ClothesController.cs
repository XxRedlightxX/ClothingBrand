using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Models;

namespace ClothingStore.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clothes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clothes.Include(c => c.Categorie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            var clothe = await _context.Clothes
                .Include(c => c.Categorie)
                .FirstOrDefaultAsync(m => m.ClotheId == id);
            if (clothe == null)
            {
                return NotFound();
            }

            return View(clothe);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "CategorieId", "NomCategorie");
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClotheId,ClotheName,Description,Quantite,Prix,Photo,CategorieId")] Clothe clothe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "CategorieId", "NomCategorie", clothe.CategorieId);
            return View(clothe);
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            var clothe = await _context.Clothes.FindAsync(id);
            if (clothe == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "CategorieId", "NomCategorie", clothe.CategorieId);
            return View(clothe);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClotheId,ClotheName,Description,Quantite,Prix,Photo,CategorieId")] Clothe clothe)
        {
            if (id != clothe.ClotheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClotheExists(clothe.ClotheId))
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
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "CategorieId", "NomCategorie", clothe.CategorieId);
            return View(clothe);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            var clothe = await _context.Clothes
                .Include(c => c.Categorie)
                .FirstOrDefaultAsync(m => m.ClotheId == id);
            if (clothe == null)
            {
                return NotFound();
            }

            return View(clothe);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clothes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clothes'  is null.");
            }
            var clothe = await _context.Clothes.FindAsync(id);
            if (clothe != null)
            {
                _context.Clothes.Remove(clothe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClotheExists(int id)
        {
          return (_context.Clothes?.Any(e => e.ClotheId == id)).GetValueOrDefault();
        }
    }
}
