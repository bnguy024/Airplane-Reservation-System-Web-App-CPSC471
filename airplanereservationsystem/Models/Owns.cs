using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Owns
    {
        public int AirplaneId { get; set; }
        public string AirlineCompanyName { get; set; }

        public virtual Airplane AirlineCompanyNameNavigation { get; set; }
        public virtual Airplane Airplane { get; set; }
    }
}
