using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtHotelDetail
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int TourDetailId { get; set; }
        public int IsUsed { get; set; }
    }
}
