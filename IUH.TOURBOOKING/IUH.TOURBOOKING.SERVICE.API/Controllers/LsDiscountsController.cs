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
    public class LsDiscountsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsDiscountsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsDiscounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsDiscount>>> GetLsDiscount()
        {
            return await _context.LsDiscount.ToListAsync();
        }

        // GET: api/LsDiscounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsDiscount>> GetLsDiscount(int id)
        {
            var lsDiscount = await _context.LsDiscount.FindAsync(id);

            if (lsDiscount == null)
            {
                return NotFound();
            }

            return lsDiscount;
        }

        // PUT: api/LsDiscounts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsDiscount(int id, LsDiscount lsDiscount)
        {
            if (id != lsDiscount.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsDiscount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsDiscountExists(id))
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

        // POST: api/LsDiscounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LsDiscount>> PostLsDiscount(LsDiscount lsDiscount)
        {
            _context.LsDiscount.Add(lsDiscount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LsDiscountExists(lsDiscount.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLsDiscount", new { id = lsDiscount.Id }, lsDiscount);
        }

        // DELETE: api/LsDiscounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsDiscount>> DeleteLsDiscount(int id)
        {
            var lsDiscount = await _context.LsDiscount.FindAsync(id);
            if (lsDiscount == null)
            {
                return NotFound();
            }

            _context.LsDiscount.Remove(lsDiscount);
            await _context.SaveChangesAsync();

            return lsDiscount;
        }

        private bool LsDiscountExists(int id)
        {
            return _context.LsDiscount.Any(e => e.Id == id);
        }
    }
}
