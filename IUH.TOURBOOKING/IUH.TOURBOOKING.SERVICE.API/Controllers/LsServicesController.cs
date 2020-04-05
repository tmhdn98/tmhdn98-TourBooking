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
    public class LsServicesController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsServicesController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsService>>> GetLsService()
        {
            return await _context.LsService.ToListAsync();
        }

        // GET: api/LsServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsService>> GetLsService(int id)
        {
            var lsService = await _context.LsService.FindAsync(id);

            if (lsService == null)
            {
                return NotFound();
            }

            return lsService;
        }

        // PUT: api/LsServices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsService(int id, LsService lsService)
        {
            if (id != lsService.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsServiceExists(id))
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

        // POST: api/LsServices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LsService>> PostLsService(LsService lsService)
        {
            _context.LsService.Add(lsService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsService", new { id = lsService.Id }, lsService);
        }

        // DELETE: api/LsServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsService>> DeleteLsService(int id)
        {
            var lsService = await _context.LsService.FindAsync(id);
            if (lsService == null)
            {
                return NotFound();
            }

            _context.LsService.Remove(lsService);
            await _context.SaveChangesAsync();

            return lsService;
        }

        private bool LsServiceExists(int id)
        {
            return _context.LsService.Any(e => e.Id == id);
        }
    }
}
