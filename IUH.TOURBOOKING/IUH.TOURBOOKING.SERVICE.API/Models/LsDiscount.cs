using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsDiscount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
