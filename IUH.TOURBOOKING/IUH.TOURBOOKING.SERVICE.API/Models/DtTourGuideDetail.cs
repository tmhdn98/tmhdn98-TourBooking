using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtTourGuideDetail
    {
        public int Id { get; set; }
        public int TourGuideId { get; set; }
        public int TourDetailId { get; set; }
    }
}
