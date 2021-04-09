using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class GetsInfoFrom
    {
        public string AirlineCompanyName { get; set; }
        public string AirportCode { get; set; }
        public int ReservationSystemId { get; set; }

        public virtual Airplane AirlineCompanyNameNavigation { get; set; }
        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual ReseverationSystem ReservationSystem { get; set; }
    }
}
