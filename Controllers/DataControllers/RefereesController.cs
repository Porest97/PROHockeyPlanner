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
    public class RefereesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefereesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Referees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Referee.Include(r => r.District).Include(r => r.Person).Include(r => r.RefCategory).Include(r => r.RefType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Referees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee = await _context.Referee
                .Include(r => r.District)
                .Include(r => r.Person)
                .Include(r => r.RefCategory)
                .Include(r => r.RefType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee == null)
            {
                return NotFound();
            }

            return View(referee);
        }

        // GET: Referees/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["RefCategoryId"] = new SelectList(_context.RefCategory, "Id", "Id");
            ViewData["RefTypeId"] = new SelectList(_context.Set<RefType>(), "Id", "Id");
            return View();
        }

        // POST: Referees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,RefNumber,RefCategoryId,RefTypeId,DistrictId")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", referee.DistrictId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee.PersonId);
            ViewData["RefCategoryId"] = new SelectList(_context.RefCategory, "Id", "Id", referee.RefCategoryId);
            ViewData["RefTypeId"] = new SelectList(_context.Set<RefType>(), "Id", "Id", referee.RefTypeId);
            return View(referee);
        }

        // GET: Referees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee = await _context.Referee.FindAsync(id);
            if (referee == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", referee.DistrictId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee.PersonId);
            ViewData["RefCategoryId"] = new SelectList(_context.RefCategory, "Id", "Id", referee.RefCategoryId);
            ViewData["RefTypeId"] = new SelectList(_context.Set<RefType>(), "Id", "Id", referee.RefTypeId);
            return View(referee);
        }

        // POST: Referees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,RefNumber,RefCategoryId,RefTypeId,DistrictId")] Referee referee)
        {
            if (id != referee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefereeExists(referee.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", referee.DistrictId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee.PersonId);
            ViewData["RefCategoryId"] = new SelectList(_context.RefCategory, "Id", "Id", referee.RefCategoryId);
            ViewData["RefTypeId"] = new SelectList(_context.Set<RefType>(), "Id", "Id", referee.RefTypeId);
            return View(referee);
        }

        // GET: Referees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee = await _context.Referee
                .Include(r => r.District)
                .Include(r => r.Person)
                .Include(r => r.RefCategory)
                .Include(r => r.RefType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee == null)
            {
                return NotFound();
            }

            return View(referee);
        }

        // POST: Referees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referee = await _context.Referee.FindAsync(id);
            _context.Referee.Remove(referee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefereeExists(int id)
        {
            return _context.Referee.Any(e => e.Id == id);
        }
    }
}
