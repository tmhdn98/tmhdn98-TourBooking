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
    public class LsAviationsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsAviationsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsAviations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsAviation>>> GetLsAviation()
        {
            return await _context.LsAviation.ToListAsync();
        }

        // GET: api/LsAviations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsAviation>> GetLsAviation(int id)
        {
            var lsAviation = await _context.LsAviation.FindAsync(id);

            if (lsAviation == null)
            {
                return NotFound();
            }

            return lsAviation;
        }

        // PUT: api/LsAviations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsAviation(int id, LsAviation lsAviation)
        {
            if (id != lsAviation.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsAviation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsAviationExists(id))
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

        // POST: api/LsAviations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LsAviation>> PostLsAviation(LsAviation lsAviation)
        {
            _context.LsAviation.Add(lsAviation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsAviation", new { id = lsAviation.Id }, lsAviation);
        }

        // DELETE: api/LsAviations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsAviation>> DeleteLsAviation(int id)
        {
            var lsAviation = await _context.LsAviation.FindAsync(id);
            if (lsAviation == null)
            {
                return NotFound();
            }

            _context.LsAviation.Remove(lsAviation);
            await _context.SaveChangesAsync();

            return lsAviation;
        }

        private bool LsAviationExists(int id)
        {
            return _context.LsAviation.Any(e => e.Id == id);
        }
    }
}
