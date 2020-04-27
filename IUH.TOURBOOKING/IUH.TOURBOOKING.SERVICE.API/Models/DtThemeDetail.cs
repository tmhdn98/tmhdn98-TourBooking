using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtThemeDetail
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int ThemeId { get; set; }
        public int IsUsed { get; set; }
    }
}
