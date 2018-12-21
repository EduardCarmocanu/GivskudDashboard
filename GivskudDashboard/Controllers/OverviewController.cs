using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Data;
using GivskudDashboard.Models;
using GivskudDashboard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GivskudDashboard.Controllers
{
	[Authorize]
	public class OverviewController : Controller
    {
		private readonly ApplicationDataContext _context;

		public OverviewController(ApplicationDataContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			Marker[] markers = await _context.Markers.ToArrayAsync();
			return View(markers);
		}

		public async Task<IActionResult> Details(int? id, decimal? lat, decimal? lng)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}

			var activeMarker = await _context.Markers
				.Include(m => m.Description)
				.SingleOrDefaultAsync(m => m.ID == id);

			if (activeMarker == null)
			{
				return RedirectToAction("Index");
			}

			Marker[] markers = await _context.Markers.ToArrayAsync();
			MarkerType[] types = await _context.MarkerTypes.ToArrayAsync();

			OverviewViewModel viewModel = new OverviewViewModel()
			{
				Lat = lat,
				Lng = lng,
				Markers = markers,
				Types = types,
				ActiveMarker = activeMarker
			};

			return View(viewModel);
		}
    }
}