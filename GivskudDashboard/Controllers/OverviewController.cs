using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Data;
using GivskudDashboard.Models;
using GivskudDashboard.ViewModels;
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
    }
}