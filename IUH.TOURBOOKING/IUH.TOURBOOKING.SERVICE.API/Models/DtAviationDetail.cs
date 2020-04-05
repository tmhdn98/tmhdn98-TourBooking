using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtAviationDetail
    {
        public int Id { get; set; }
        public int AviationId { get; set; }
        public int TourDetailId { get; set; }
    }
}
