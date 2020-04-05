using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsCustomerInfo
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Deposit { get; set; }
        public string Requirement { get; set; }
        public string TourDetailId { get; set; }
        public int IsUsed { get; set; }
    }
}
