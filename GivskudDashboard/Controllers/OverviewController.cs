using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Data;
using GivskudDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GivskudDashboard.Controllers
{
    public class OverviewController : Controller
    {
		private readonly ApplicationDataContext _context;

		public OverviewController(ApplicationDataContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var markers = _context.Markers.ToArray();
			return View(markers);
		}

		public IActionResult Details(int? id, decimal? lat, decimal? lng)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}

			var marker = _context.Markers
				.Include(m => m.Description)
				.SingleOrDefault(m => m.ID == id);

			if (marker == null)
			{
				return RedirectToAction("Index");
			}

			var markersList = _context.Markers.ToArray();
			var types = _context.MarkerTypes.ToDictionary(t => t.ID);

			ViewBag.MarkersList = markersList;
			ViewBag.Types = types;

			if (lat != null && lat != null)
			{
				ViewBag.Lat = lat;
				ViewBag.Lng = lng;
			}

			return View(marker);
		}
    }
}