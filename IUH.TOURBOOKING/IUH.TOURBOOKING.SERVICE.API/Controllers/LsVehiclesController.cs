﻿using System;
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
    public class LsVehiclesController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public LsVehiclesController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/LsVehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LsVehicle>>> GetLsVehicle()
        {
            return await _context.LsVehicle.ToListAsync();
        }

        // GET: api/LsVehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LsVehicle>> GetLsVehicle(int id)
        {
            var lsVehicle = await _context.LsVehicle.FindAsync(id);

            if (lsVehicle == null)
            {
                return NotFound();
            }

            return lsVehicle;
        }

        // PUT: api/LsVehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLsVehicle(int id, LsVehicle lsVehicle)
        {
            if (id != lsVehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(lsVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsVehicleExists(id))
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

        // POST: api/LsVehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LsVehicle>> PostLsVehicle(LsVehicle lsVehicle)
        {
            _context.LsVehicle.Add(lsVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLsVehicle", new { id = lsVehicle.Id }, lsVehicle);
        }

        // DELETE: api/LsVehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LsVehicle>> DeleteLsVehicle(int id)
        {
            var lsVehicle = await _context.LsVehicle.FindAsync(id);
            if (lsVehicle == null)
            {
                return NotFound();
            }

            _context.LsVehicle.Remove(lsVehicle);
            await _context.SaveChangesAsync();

            return lsVehicle;
        }

        private bool LsVehicleExists(int id)
        {
            return _context.LsVehicle.Any(e => e.Id == id);
        }
    }
}
