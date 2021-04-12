using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class AirplaneRoute
    {
        public AirplaneRoute()
        {
            Flies = new HashSet<Flies>();
        }

        public string AirportCode { get; set; }
        public string AmountOfTime { get; set; }
        public int RouteNum { get; set; }
        public string Status { get; set; }

        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual FlightLeg FlightLeg { get; set; }
        public virtual ICollection<Flies> Flies { get; set; }
    }
}
