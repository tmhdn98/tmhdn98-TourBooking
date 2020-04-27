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
    public class LsToursController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsToursController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsTours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsTour>>> GetLsTour()
        {
            return await _context.LsTour.ToListAsync();
        }

        // GET: api/LsTours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsTour>> GetLsTour(int id)
        {
            var lsTour = await _context.LsTour.FindAsync(id);

            if (lsTour == null)
            {
                return NotFound();
            }

            return lsTour;
        }

        // PUT: api/LsTours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsTour(int id, LsTour lsTour)
        {
            if (id != lsTour.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsTour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsTourExists(id))
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

        // POST: api/LsTours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsTour>> PostLsTour(LsTour lsTour)
        {
            _context.LsTour.Add(lsTour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsTour", new { id = lsTour.Id }, lsTour);
        }

        // DELETE: api/LsTours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsTour>> DeleteLsTour(int id)
        {
            var lsTour = await _context.LsTour.FindAsync(id);
            if (lsTour == null)
            {
                return NotFound();
            }

            _context.LsTour.Remove(lsTour);
            await _context.SaveChangesAsync();

            return lsTour;
        }

        private bool LsTourExists(int id)
        {
            return _context.LsTour.Any(e => e.Id == id);
        }
    }
}
