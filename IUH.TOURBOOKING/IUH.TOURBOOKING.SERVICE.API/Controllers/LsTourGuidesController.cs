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
    public class LsTourGuidesController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsTourGuidesController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsTourGuides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsTourGuide>>> GetLsTourGuide()
        {
            return await _context.LsTourGuide.ToListAsync();
        }

        // GET: api/LsTourGuides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsTourGuide>> GetLsTourGuide(int id)
        {
            var lsTourGuide = await _context.LsTourGuide.FindAsync(id);

            if (lsTourGuide == null)
            {
                return NotFound();
            }

            return lsTourGuide;
        }

        // PUT: api/LsTourGuides/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsTourGuide(int id, LsTourGuide lsTourGuide)
        {
            if (id != lsTourGuide.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsTourGuide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsTourGuideExists(id))
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

        // POST: api/LsTourGuides
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsTourGuide>> PostLsTourGuide(LsTourGuide lsTourGuide)
        {
            _context.LsTourGuide.Add(lsTourGuide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsTourGuide", new { id = lsTourGuide.Id }, lsTourGuide);
        }

        // DELETE: api/LsTourGuides/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsTourGuide>> DeleteLsTourGuide(int id)
        {
            var lsTourGuide = await _context.LsTourGuide.FindAsync(id);
            if (lsTourGuide == null)
            {
                return NotFound();
            }

            _context.LsTourGuide.Remove(lsTourGuide);
            await _context.SaveChangesAsync();

            return lsTourGuide;
        }

        private bool LsTourGuideExists(int id)
        {
            return _context.LsTourGuide.Any(e => e.Id == id);
        }
    }
}
