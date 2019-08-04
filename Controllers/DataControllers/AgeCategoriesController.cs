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
    public class AgeCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgeCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AgeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgeCategory.ToListAsync());
        }

        // GET: AgeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ageCategory = await _context.AgeCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ageCategory == null)
            {
                return NotFound();
            }

            return View(ageCategory);
        }

        // GET: AgeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AgeCategoryName")] AgeCategory ageCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ageCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ageCategory);
        }

        // GET: AgeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ageCategory = await _context.AgeCategory.FindAsync(id);
            if (ageCategory == null)
            {
                return NotFound();
            }
            return View(ageCategory);
        }

        // POST: AgeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AgeCategoryName")] AgeCategory ageCategory)
        {
            if (id != ageCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ageCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgeCategoryExists(ageCategory.Id))
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
            return View(ageCategory);
        }

        // GET: AgeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ageCategory = await _context.AgeCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ageCategory == null)
            {
                return NotFound();
            }

            return View(ageCategory);
        }

        // POST: AgeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ageCategory = await _context.AgeCategory.FindAsync(id);
            _context.AgeCategory.Remove(ageCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgeCategoryExists(int id)
        {
            return _context.AgeCategory.Any(e => e.Id == id);
        }
    }
}
