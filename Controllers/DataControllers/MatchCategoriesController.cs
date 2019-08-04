using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROHockeyPlanner.Data;
using PROHockeyPlanner.Models.DataModels;

namespace PROHockeyPlanner.Controllers.DataControllers
{
    public class MatchCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatchCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.MatchCategory.ToListAsync());
        }

        // GET: MatchCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchCategory = await _context.MatchCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchCategory == null)
            {
                return NotFound();
            }

            return View(matchCategory);
        }

        // GET: MatchCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatchCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchCategoryName")] MatchCategory matchCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchCategory);
        }

        // GET: MatchCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchCategory = await _context.MatchCategory.FindAsync(id);
            if (matchCategory == null)
            {
                return NotFound();
            }
            return View(matchCategory);
        }

        // POST: MatchCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchCategoryName")] MatchCategory matchCategory)
        {
            if (id != matchCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchCategoryExists(matchCategory.Id))
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
            return View(matchCategory);
        }

        // GET: MatchCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchCategory = await _context.MatchCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchCategory == null)
            {
                return NotFound();
            }

            return View(matchCategory);
        }

        // POST: MatchCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchCategory = await _context.MatchCategory.FindAsync(id);
            _context.MatchCategory.Remove(matchCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchCategoryExists(int id)
        {
            return _context.MatchCategory.Any(e => e.Id == id);
        }
    }
}
