using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class GetsInfoFrom
    {
        public int ReservationSystemId { get; set; }
        public string AirlineCompanyName { get; set; }
        public string AirportCode { get; set; }

        public virtual Airplane AirlineCompanyNameNavigation { get; set; }
        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual ReseverationSystem ReservationSystem { get; set; }
    }
}
