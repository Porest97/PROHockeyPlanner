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
    public class RefCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefCategory.ToListAsync());
        }

        // GET: RefCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refCategory = await _context.RefCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refCategory == null)
            {
                return NotFound();
            }

            return View(refCategory);
        }

        // GET: RefCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefCategoryName")] RefCategory refCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refCategory);
        }

        // GET: RefCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refCategory = await _context.RefCategory.FindAsync(id);
            if (refCategory == null)
            {
                return NotFound();
            }
            return View(refCategory);
        }

        // POST: RefCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefCategoryName")] RefCategory refCategory)
        {
            if (id != refCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefCategoryExists(refCategory.Id))
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
            return View(refCategory);
        }

        // GET: RefCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refCategory = await _context.RefCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refCategory == null)
            {
                return NotFound();
            }

            return View(refCategory);
        }

        // POST: RefCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refCategory = await _context.RefCategory.FindAsync(id);
            _context.RefCategory.Remove(refCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefCategoryExists(int id)
        {
            return _context.RefCategory.Any(e => e.Id == id);
        }
    }
}
