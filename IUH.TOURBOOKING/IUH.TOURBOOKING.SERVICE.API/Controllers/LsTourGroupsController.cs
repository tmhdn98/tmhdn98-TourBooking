using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IUH.TOURBOOKING.SERVICE.API.Models;

namespace IUH.TOURBOOKING.SERVICE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LsTourGroupsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsTourGroupsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsTourGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsTourGroup>>> GetLsTourGroup()
        {
            return await _context.LsTourGroup.ToListAsync();
        }

        // GET: api/LsTourGroups/getDomestic
        [HttpGet("getDomestic")]
        public async Task<ActionResult<IEnumerable<LsTourGroup>>> GetLsTourGroupDomestic()
        {
            return await _context.LsTourGroup.Where(p => p.DomesticOrForeign == true).ToListAsync();
        }

        // GET: api/LsTourGroups
        [HttpGet("getForeign")]
        public async Task<ActionResult<IEnumerable<LsTourGroup>>> GetLsTourGroupForeign()
        {
            return await _context.LsTourGroup.Where(p => p.DomesticOrForeign == false).ToListAsync();
        }

        // GET: api/LsTourGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsTourGroup>> GetLsTourGroup(int id)
        {
            var lsTourGroup = await _context.LsTourGroup.FindAsync(id);

            if (lsTourGroup == null)
            {
                return NotFound();
            }

            return lsTourGroup;
        }

        // PUT: api/LsTourGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsTourGroup(int id, LsTourGroup lsTourGroup)
        {
            if (id != lsTourGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsTourGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsTourGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LsTourGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsTourGroup>> PostLsTourGroup(LsTourGroup lsTourGroup)
        {
            _context.LsTourGroup.Add(lsTourGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsTourGroup", new { id = lsTourGroup.Id }, lsTourGroup);
        }

        // DELETE: api/LsTourGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsTourGroup>> DeleteLsTourGroup(int id)
        {
            var lsTourGroup = await _context.LsTourGroup.FindAsync(id);
            if (lsTourGroup == null)
            {
                return NotFound();
            }

            _context.LsTourGroup.Remove(lsTourGroup);
            await _context.SaveChangesAsync();

            return lsTourGroup;
        }

        private bool LsTourGroupExists(int id)
        {
            return _context.LsTourGroup.Any(e => e.Id == id);
        }
    }
}
