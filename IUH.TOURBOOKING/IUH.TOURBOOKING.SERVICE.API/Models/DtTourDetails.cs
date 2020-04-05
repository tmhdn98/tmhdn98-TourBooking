using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtTourDetails
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string Code { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Seats { get; set; }
        public string SeatBooked { get; set; }
        public string SeatRemaining { get; set; }
        public string Price { get; set; }
        public string Period { get; set; }
        public DateTime DateCreated { get; set; }
        public string DiscountCodeId { get; set; }
        public int IsUsed { get; set; }
    }
}
