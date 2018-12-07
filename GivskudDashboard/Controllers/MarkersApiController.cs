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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GivskudDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[EnableCors("GivskudPolicy")]
    public class MarkersApiController : ControllerBase
    {

		private readonly ApplicationDataContext _context;

		public MarkersApiController(ApplicationDataContext context)
		{
			_context = context;
		}

        // GET: api/MarkersApi
        [HttpGet]
        public Marker[] Get()
        {
			return _context.Markers.Include(m => m.Description).ToArray();
        }
    }
}
