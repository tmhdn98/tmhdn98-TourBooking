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
    public class LsCustomerInfoesController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsCustomerInfoesController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsCustomerInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsCustomerInfo>>> GetLsCustomerInfo()
        {
            return await _context.LsCustomerInfo.ToListAsync();
        }

        // GET: api/LsCustomerInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsCustomerInfo>> GetLsCustomerInfo(int id)
        {
            var lsCustomerInfo = await _context.LsCustomerInfo.FindAsync(id);

            if (lsCustomerInfo == null)
            {
                return NotFound();
            }

            return lsCustomerInfo;
        }

        // PUT: api/LsCustomerInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsCustomerInfo(int id, LsCustomerInfo lsCustomerInfo)
        {
            if (id != lsCustomerInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsCustomerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsCustomerInfoExists(id))
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

        // POST: api/LsCustomerInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsCustomerInfo>> PostLsCustomerInfo(LsCustomerInfo lsCustomerInfo)
        {
            _context.LsCustomerInfo.Add(lsCustomerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsCustomerInfo", new { id = lsCustomerInfo.Id }, lsCustomerInfo);
        }

        // DELETE: api/LsCustomerInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsCustomerInfo>> DeleteLsCustomerInfo(int id)
        {
            var lsCustomerInfo = await _context.LsCustomerInfo.FindAsync(id);
            if (lsCustomerInfo == null)
            {
                return NotFound();
            }

            _context.LsCustomerInfo.Remove(lsCustomerInfo);
            await _context.SaveChangesAsync();

            return lsCustomerInfo;
        }

        private bool LsCustomerInfoExists(int id)
        {
            return _context.LsCustomerInfo.Any(e => e.Id == id);
        }
    }
}
