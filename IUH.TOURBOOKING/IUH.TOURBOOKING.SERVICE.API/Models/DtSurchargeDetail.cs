using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtSurchargeDetail
    {
        public int Id { get; set; }
        public int SurchargeId { get; set; }
        public int TourDetailId { get; set; }
    }
}
