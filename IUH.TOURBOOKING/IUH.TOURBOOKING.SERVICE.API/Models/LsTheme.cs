using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsTheme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string KeyWord { get; set; }
        public string Image { get; set; }
        public int IsUsed { get; set; }
    }
}
