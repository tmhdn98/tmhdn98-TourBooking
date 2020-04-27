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
    public class LsHotelsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsHotelsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsHotel>>> GetLsHotel()
        {
            return await _context.LsHotel.ToListAsync();
        }

        // GET: api/LsHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsHotel>> GetLsHotel(int id)
        {
            var lsHotel = await _context.LsHotel.FindAsync(id);

            if (lsHotel == null)
            {
                return NotFound();
            }

            return lsHotel;
        }

        // PUT: api/LsHotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsHotel(int id, LsHotel lsHotel)
        {
            if (id != lsHotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsHotelExists(id))
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

        // POST: api/LsHotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsHotel>> PostLsHotel(LsHotel lsHotel)
        {
            _context.LsHotel.Add(lsHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsHotel", new { id = lsHotel.Id }, lsHotel);
        }

        // DELETE: api/LsHotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsHotel>> DeleteLsHotel(int id)
        {
            var lsHotel = await _context.LsHotel.FindAsync(id);
            if (lsHotel == null)
            {
                return NotFound();
            }

            _context.LsHotel.Remove(lsHotel);
            await _context.SaveChangesAsync();

            return lsHotel;
        }

        private bool LsHotelExists(int id)
        {
            return _context.LsHotel.Any(e => e.Id == id);
        }
    }
}
