using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GivskudDashboard.Models;
using GivskudDashboard.Data;
using Microsoft.AspNetCore.Authorization;
using GivskudDashboard.ViewModels;

namespace GivskudDashboard.Controllers
{
	[Authorize]
	public class MarkersController : Controller
    {
        private readonly MarkersDataContext _context;

		public MarkersController(MarkersDataContext context)
        {
            _context = context;
        }

		// GET: Markers
		public async Task<IActionResult> Index()
        {
			ViewBag.Types = await _context.MarkerTypes.ToArrayAsync();
			List<Marker> markers = await _context.Markers.ToListAsync();

			AllMarkersViewModel viewModel = new AllMarkersViewModel()
			{
				ColumnTitles = new String[] { "Marker Title", "Marker Type" },
				Markers = _context.Markers.ToList(),
				Types = _context.MarkerTypes.ToArray()
			};

			return View(viewModel);
        }

        // GET: Markers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Markers.FirstOrDefaultAsync(m => m.ID == id);

            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // GET: Markers/Create
        public async Task<IActionResult> Create()
        {
			CreateMarkerViewModel viewModel = new CreateMarkerViewModel()
			{
				Types = await _context.MarkerTypes.ToListAsync(),
				Marker = new Marker()
			};
 
			return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Title,Lat,Lng,MarkerTypeID,Description")] Marker marker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marker);
                _context.SaveChanges();
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

            var marker = await _context.Markers.Include(m => m.Description).SingleOrDefaultAsync(m => m.ID == id);
            if (marker == null)
            {
                return NotFound();
            }

			List<MarkerType> types = _context.MarkerTypes.ToList();

			EditMarkerViewModel viewModel = new EditMarkerViewModel()
			{
				Marker = marker,
				Types = types
			};

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Lat,Lng,MarkerTypeID,Description")] Marker marker)
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
                return RedirectToAction("Details", "Overview", new { id = marker.ID, lat = marker.Lat, lng = marker.Lng});
            }
            return View(marker);
        }

		// GET: Markers/Delete/5
		[ActionName("Delete")]
		public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = _context.Markers.Include(m => m.Description).FirstOrDefault(m => m.ID == id);
			var description = _context.Descriptions.FirstOrDefault(d => d.ID == marker.Description.ID);

			if (marker == null || description == null)
            {
                return NotFound();
            }

			_context.Markers.Remove(marker);
			_context.Descriptions.Remove(description);
			_context.SaveChanges();

			return RedirectToAction("Index");
        }


        private bool MarkerExists(int id)
        {
            return _context.Markers.Any(e => e.ID == id);
        }
    }
}
