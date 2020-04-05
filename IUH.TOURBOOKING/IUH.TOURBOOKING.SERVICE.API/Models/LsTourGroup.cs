using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsTourGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string KeyWord { get; set; }
        public string LinkName { get; set; }
        public string Introduce { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int IsUsed { get; set; }
    }
}
