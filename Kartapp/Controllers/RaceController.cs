using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kartapp.Models;

namespace Kartapp.Controllers
{
    public class RaceController : Controller
    {
        private readonly KartappContext _context;

        public RaceController(KartappContext context)
        {
            _context = context;
        }

        // GET: Race
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceModel.ToListAsync());
        }

        // GET: Race/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceModel = await _context.RaceModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (raceModel == null)
            {
                return NotFound();
            }

            return View(raceModel);
        }

        // GET: Race/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Race/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Local,EventDate,Type")] RaceModel raceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceModel);
        }

        // GET: Race/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceModel = await _context.RaceModel.SingleOrDefaultAsync(m => m.ID == id);
            if (raceModel == null)
            {
                return NotFound();
            }
            return View(raceModel);
        }

        // POST: Race/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Local,EventDate,Type")] RaceModel raceModel)
        {
            if (id != raceModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceModelExists(raceModel.ID))
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
            return View(raceModel);
        }

        // GET: Race/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceModel = await _context.RaceModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (raceModel == null)
            {
                return NotFound();
            }

            return View(raceModel);
        }

        // POST: Race/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceModel = await _context.RaceModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.RaceModel.Remove(raceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceModelExists(int id)
        {
            return _context.RaceModel.Any(e => e.ID == id);
        }
    }
}
