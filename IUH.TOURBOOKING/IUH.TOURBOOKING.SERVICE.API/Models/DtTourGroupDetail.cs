using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtTourGroupDetail
    {
        public int Id { get; set; }
        public int TourGroupId { get; set; }
        public int TourId { get; set; }
        public int IsUsed { get; set; }
    }
}
