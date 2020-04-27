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
    public class LsThemesController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsThemesController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsThemes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsTheme>>> GetLsTheme()
        {
            return await _context.LsTheme.ToListAsync();
        }

        // GET: api/LsThemes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsTheme>> GetLsTheme(int id)
        {
            var lsTheme = await _context.LsTheme.FindAsync(id);

            if (lsTheme == null)
            {
                return NotFound();
            }

            return lsTheme;
        }

        // PUT: api/LsThemes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsTheme(int id, LsTheme lsTheme)
        {
            if (id != lsTheme.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsTheme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsThemeExists(id))
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

        // POST: api/LsThemes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsTheme>> PostLsTheme(LsTheme lsTheme)
        {
            _context.LsTheme.Add(lsTheme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsTheme", new { id = lsTheme.Id }, lsTheme);
        }

        // DELETE: api/LsThemes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsTheme>> DeleteLsTheme(int id)
        {
            var lsTheme = await _context.LsTheme.FindAsync(id);
            if (lsTheme == null)
            {
                return NotFound();
            }

            _context.LsTheme.Remove(lsTheme);
            await _context.SaveChangesAsync();

            return lsTheme;
        }

        private bool LsThemeExists(int id)
        {
            return _context.LsTheme.Any(e => e.Id == id);
        }
    }
}
