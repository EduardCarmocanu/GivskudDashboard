using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Data;
using GivskudDashboard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GivskudDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[EnableCors("GivskudPolicy")]
    public class MarkerTypesApiController : ControllerBase
    {
		private readonly ApplicationDataContext _context;

		public MarkerTypesApiController(ApplicationDataContext context)
		{
			_context = context;
		}

		// GET: api/MarkerTypesApi
		[HttpGet]
		public MarkerType[] Get()
		{
			return _context.MarkerTypes.ToArray();
		}
	}
}