using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Data;
using GivskudDashboard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GivskudDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[EnableCors("GivskudPolicy")]
    public class GetTypesController : ControllerBase
    {
		private readonly ApplicationDataContext _context;

		public GetTypesController(ApplicationDataContext context)
		{
			_context = context;
		}

		// GET: api/GetTypes/
		[HttpGet]
		public async Task<IActionResult> GetTypes()
		{
			MarkerType[] markers = await _context.MarkerTypes.ToArrayAsync();

			return Ok(markers);
		}
	}
}