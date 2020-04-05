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
    public class DtTourDetailsController : ControllerBase
    {
        private readonly TravelTour_DBContext _context;

        public DtTourDetailsController(TravelTour_DBContext context)
        {
            _context = context;
        }

        // GET: api/DtTourDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtTourDetails>>> GetDtTourDetails()
        {
            return await _context.DtTourDetails.ToListAsync();
        }

        //// GET: api/DtTourDetails/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DtTourDetails>> GetDtTourDetails(int id)
        //{
        //    var dtTourDetails = await _context.DtTourDetails.FindAsync(id);

        //    if (dtTourDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return dtTourDetails;
        //}

        // GET: api/DtTourDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtTourDetails>> GetDtTourDetails(int tourID)
        {
            var dtTourDetails = await _context.DtTourDetails.Where(dt => dt.TourId == tourID).FirstOrDefaultAsync();

            if (dtTourDetails == null)
            {
                return NotFound();
            }

            return dtTourDetails;
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<object>> GetDtTourDetailsInfo(int tourID)
        {
            if (tourID == 0)
            {
                return BadRequest();
            }
            var data = await (from tourDetail in _context.DtTourDetails
                       join service in _context.DtServiceDetail on tourDetail.Id equals service.TourDetailId
                       join hotel in _context.DtHotelDetail on tourDetail.Id equals hotel.TourDetailId
                       join aviation in _context.DtAviationDetail on tourDetail.Id equals aviation.TourDetailId
                       join vehicle in _context.DtVehicleDetail on tourDetail.Id equals vehicle.TourDetailId
                       join guide in _context.DtTourGuideDetail on tourDetail.Id equals guide.TourDetailId
                       join surcharge in _context.DtSurchargeDetail on tourDetail.Id equals surcharge.TourDetailId
                       join payment in _context.DtPaymentDetail on tourDetail.Id equals payment.TourDetailId
                       where(tourDetail.TourId == tourID)
                       select new
                       {
                           Id = tourDetail.Id,
                           services = _context.LsService.Where(ser => ser.Id == service.TourDetailId).ToList(),
                           hotels = _context.LsHotel.Where(hol => hol.Id == hotel.TourDetailId).ToList(),
                           aviations = _context.LsAviation.Where(avi => avi.Id == aviation.TourDetailId).ToList(),
                           vehicles = _context.LsVehicle.Where(veh => veh.Id == vehicle.TourDetailId).ToList(),
                           guides = _context.LsTourGuide.Where(gui => gui.Id == guide.TourDetailId).ToList(),
                           surcharges = _context.LsSurcharge.Where(sur => sur.Id == surcharge.TourDetailId).ToList(),
                           payments = _context.LsPayments.Where(pay => pay.Id == payment.TourDetailId).ToList(),
                       }).FirstOrDefaultAsync();
            return data;
        }

        // PUT: api/DtTourDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDtTourDetails(int id, DtTourDetails dtTourDetails)
        {
            if (id != dtTourDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(dtTourDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DtTourDetailsExists(id))
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

        // POST: api/DtTourDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DtTourDetails>> PostDtTourDetails(DtTourDetails dtTourDetails)
        {
            _context.DtTourDetails.Add(dtTourDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDtTourDetails", new { id = dtTourDetails.Id }, dtTourDetails);
        }

        // DELETE: api/DtTourDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DtTourDetails>> DeleteDtTourDetails(int id)
        {
            var dtTourDetails = await _context.DtTourDetails.FindAsync(id);
            if (dtTourDetails == null)
            {
                return NotFound();
            }

            _context.DtTourDetails.Remove(dtTourDetails);
            await _context.SaveChangesAsync();

            return dtTourDetails;
        }

        private bool DtTourDetailsExists(int id)
        {
            return _context.DtTourDetails.Any(e => e.Id == id);
        }
    }
}
