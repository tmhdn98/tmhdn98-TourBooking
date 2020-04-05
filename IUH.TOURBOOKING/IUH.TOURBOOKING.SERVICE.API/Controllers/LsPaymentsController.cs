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
    public class LsPaymentsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsPaymentsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsPayments>>> GetLsPayments()
        {
            return await _context.LsPayments.ToListAsync();
        }

        // GET: api/LsPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsPayments>> GetLsPayments(int id)
        {
            var lsPayments = await _context.LsPayments.FindAsync(id);

            if (lsPayments == null)
            {
                return NotFound();
            }

            return lsPayments;
        }

        // PUT: api/LsPayments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsPayments(int id, LsPayments lsPayments)
        {
            if (id != lsPayments.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsPaymentsExists(id))
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

        // POST: api/LsPayments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LsPayments>> PostLsPayments(LsPayments lsPayments)
        {
            _context.LsPayments.Add(lsPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsPayments", new { id = lsPayments.Id }, lsPayments);
        }

        // DELETE: api/LsPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsPayments>> DeleteLsPayments(int id)
        {
            var lsPayments = await _context.LsPayments.FindAsync(id);
            if (lsPayments == null)
            {
                return NotFound();
            }

            _context.LsPayments.Remove(lsPayments);
            await _context.SaveChangesAsync();

            return lsPayments;
        }

        private bool LsPaymentsExists(int id)
        {
            return _context.LsPayments.Any(e => e.Id == id);
        }
    }
}
