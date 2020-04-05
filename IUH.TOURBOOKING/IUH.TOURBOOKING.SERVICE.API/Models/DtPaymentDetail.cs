using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class DtPaymentDetail
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int TourDetailId { get; set; }
    }
}
