using System;
using System.Collections.Generic;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class LsCurrencyUnit
    {
        public int Id { get; set; }
        public string TypeMoney { get; set; }
        public string Name { get; set; }
        public int ExchangeRate { get; set; }
        public int IsUsed { get; set; }
    }
}
