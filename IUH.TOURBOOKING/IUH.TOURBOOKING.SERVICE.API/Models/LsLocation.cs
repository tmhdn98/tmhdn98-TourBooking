using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsLocation
    {
        public int Id { get; set; }
        public string TourId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsUsed { get; set; }
    }
}
