using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsAviation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsUsed { get; set; }
    }
}
