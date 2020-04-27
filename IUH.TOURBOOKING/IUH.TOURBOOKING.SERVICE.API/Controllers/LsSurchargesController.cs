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
    public class LsSurchargesController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsSurchargesController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsSurcharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsSurcharge>>> GetLsSurcharge()
        {
            return await _context.LsSurcharge.ToListAsync();
        }

        // GET: api/LsSurcharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsSurcharge>> GetLsSurcharge(int id)
        {
            var lsSurcharge = await _context.LsSurcharge.FindAsync(id);

            if (lsSurcharge == null)
            {
                return NotFound();
            }

            return lsSurcharge;
        }

        // PUT: api/LsSurcharges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsSurcharge(int id, LsSurcharge lsSurcharge)
        {
            if (id != lsSurcharge.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsSurcharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsSurchargeExists(id))
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

        // POST: api/LsSurcharges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsSurcharge>> PostLsSurcharge(LsSurcharge lsSurcharge)
        {
            _context.LsSurcharge.Add(lsSurcharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsSurcharge", new { id = lsSurcharge.Id }, lsSurcharge);
        }

        // DELETE: api/LsSurcharges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsSurcharge>> DeleteLsSurcharge(int id)
        {
            var lsSurcharge = await _context.LsSurcharge.FindAsync(id);
            if (lsSurcharge == null)
            {
                return NotFound();
            }

            _context.LsSurcharge.Remove(lsSurcharge);
            await _context.SaveChangesAsync();

            return lsSurcharge;
        }

        private bool LsSurchargeExists(int id)
        {
            return _context.LsSurcharge.Any(e => e.Id == id);
        }
    }
}
