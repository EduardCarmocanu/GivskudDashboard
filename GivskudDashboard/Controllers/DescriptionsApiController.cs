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
    public class DescriptionsApiController : ControllerBase
    {
		private readonly ApplicationDataContext _context;

		public DescriptionsApiController(ApplicationDataContext context)
		{
			_context = context;
		}

        // GET: api/DescriptionsApi
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/DescriptionsApi/5
        [HttpGet("{id}")]
        public Description Get(int? id)
        {
            return _context.Descriptions.SingleOrDefault(d => d.ID == id);
        }
    }
}
