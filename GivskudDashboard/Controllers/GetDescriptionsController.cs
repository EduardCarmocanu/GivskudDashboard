using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GivskudDashboard.Data;
using GivskudDashboard.Models;

namespace GivskudDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDescriptionsController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public GetDescriptionsController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/GetDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var description = await _context.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return Ok(description);
        }
    }
}