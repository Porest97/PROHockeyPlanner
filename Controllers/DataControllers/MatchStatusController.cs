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
    public class MatchStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatchStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.MatchStatus.ToListAsync());
        }

        // GET: MatchStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchStatus = await _context.MatchStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchStatus == null)
            {
                return NotFound();
            }

            return View(matchStatus);
        }

        // GET: MatchStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatchStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchStatusName")] MatchStatus matchStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchStatus);
        }

        // GET: MatchStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchStatus = await _context.MatchStatus.FindAsync(id);
            if (matchStatus == null)
            {
                return NotFound();
            }
            return View(matchStatus);
        }

        // POST: MatchStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchStatusName")] MatchStatus matchStatus)
        {
            if (id != matchStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchStatusExists(matchStatus.Id))
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
            return View(matchStatus);
        }

        // GET: MatchStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchStatus = await _context.MatchStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchStatus == null)
            {
                return NotFound();
            }

            return View(matchStatus);
        }

        // POST: MatchStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchStatus = await _context.MatchStatus.FindAsync(id);
            _context.MatchStatus.Remove(matchStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchStatusExists(int id)
        {
            return _context.MatchStatus.Any(e => e.Id == id);
        }
    }
}
