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
    public class LsCurrencyUnitsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsCurrencyUnitsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsCurrencyUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsCurrencyUnit>>> GetLsCurrencyUnit()
        {
            return await _context.LsCurrencyUnit.ToListAsync();
        }

        // GET: api/LsCurrencyUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsCurrencyUnit>> GetLsCurrencyUnit(int id)
        {
            var lsCurrencyUnit = await _context.LsCurrencyUnit.FindAsync(id);

            if (lsCurrencyUnit == null)
            {
                return NotFound();
            }

            return lsCurrencyUnit;
        }

        // PUT: api/LsCurrencyUnits/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsCurrencyUnit(int id, LsCurrencyUnit lsCurrencyUnit)
        {
            if (id != lsCurrencyUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsCurrencyUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsCurrencyUnitExists(id))
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

        // POST: api/LsCurrencyUnits
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LsCurrencyUnit>> PostLsCurrencyUnit(LsCurrencyUnit lsCurrencyUnit)
        {
            _context.LsCurrencyUnit.Add(lsCurrencyUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsCurrencyUnit", new { id = lsCurrencyUnit.Id }, lsCurrencyUnit);
        }

        // DELETE: api/LsCurrencyUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsCurrencyUnit>> DeleteLsCurrencyUnit(int id)
        {
            var lsCurrencyUnit = await _context.LsCurrencyUnit.FindAsync(id);
            if (lsCurrencyUnit == null)
            {
                return NotFound();
            }

            _context.LsCurrencyUnit.Remove(lsCurrencyUnit);
            await _context.SaveChangesAsync();

            return lsCurrencyUnit;
        }

        private bool LsCurrencyUnitExists(int id)
        {
            return _context.LsCurrencyUnit.Any(e => e.Id == id);
        }
    }
}
