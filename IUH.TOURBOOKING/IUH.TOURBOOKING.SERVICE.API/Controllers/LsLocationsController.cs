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
    public class LsLocationsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsLocationsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsLocation>>> GetLsLocation()
        {
            return await _context.LsLocation.ToListAsync();
        }

        // GET: api/LsLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsLocation>> GetLsLocation(int id)
        {
            var lsLocation = await _context.LsLocation.FindAsync(id);

            if (lsLocation == null)
            {
                return NotFound();
            }

            return lsLocation;
        }

        // PUT: api/LsLocations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsLocation(int id, LsLocation lsLocation)
        {
            if (id != lsLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsLocationExists(id))
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

        // POST: api/LsLocations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LsLocation>> PostLsLocation(LsLocation lsLocation)
        {
            _context.LsLocation.Add(lsLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsLocation", new { id = lsLocation.Id }, lsLocation);
        }

        // DELETE: api/LsLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsLocation>> DeleteLsLocation(int id)
        {
            var lsLocation = await _context.LsLocation.FindAsync(id);
            if (lsLocation == null)
            {
                return NotFound();
            }

            _context.LsLocation.Remove(lsLocation);
            await _context.SaveChangesAsync();

            return lsLocation;
        }

        private bool LsLocationExists(int id)
        {
            return _context.LsLocation.Any(e => e.Id == id);
        }
    }
}
