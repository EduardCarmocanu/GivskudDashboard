using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GivskudDashboard.Models;
using GivskudDashboard.Data;

namespace GivskudDashboard.Controllers
{
    public class MarkersController : Controller
    {
        private readonly ApplicationDataContext _context;

        public MarkersController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: Markers
        public async Task<IActionResult> Index()
        {
			ViewBag.Types = _context.MarkerTypes.ToDictionary(x => x.ID);
            return View(await _context.Markers.ToListAsync());
        }

        // GET: Markers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Markers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // GET: Markers/Create
        public IActionResult Create()
        {
			ViewBag.Types = _context.MarkerTypes.ToList();
            return View();
        }

        // POST: Markers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Lat,Lng,MarkerTypeID,Description")] Marker marker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marker);
        }

        // GET: Markers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Markers.FindAsync(id);
            if (marker == null)
            {
                return NotFound();
            }
            return View(marker);
        }

        // POST: Markers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Lat,Lng,MarkerTypeID")] Marker marker)
        {
            if (id != marker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkerExists(marker.ID))
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
            return View(marker);
        }

        // GET: Markers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Markers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // POST: Markers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marker = await _context.Markers.FindAsync(id);
            _context.Markers.Remove(marker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkerExists(int id)
        {
            return _context.Markers.Any(e => e.ID == id);
        }
    }
}
