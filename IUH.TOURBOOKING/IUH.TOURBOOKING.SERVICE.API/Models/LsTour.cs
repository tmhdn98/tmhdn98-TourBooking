using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsTour
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Departure { get; set; }
        public string Ends { get; set; }
        public string Image { get; set; }
        public bool IsUsed { get; set; }
    }
}
