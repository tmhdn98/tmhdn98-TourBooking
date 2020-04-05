using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsTourGuide
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Sex { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int IsUsed { get; set; }
    }
}
