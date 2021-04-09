using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class FlightLeg
    {
        public FlightLeg()
        {
            ArrivalLegNumNavigation = new HashSet<Arrival>();
            ArrivalRouteNumNavigation = new HashSet<Arrival>();
            DepartureLegNumNavigation = new HashSet<Departure>();
            DepartureRouteNumNavigation = new HashSet<Departure>();
            LegInstance = new HashSet<LegInstance>();
            Provides = new HashSet<Provides>();
        }

        public int LegNum { get; set; }
        public int RouteNum { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Arrival> ArrivalLegNumNavigation { get; set; }
        public virtual ICollection<Arrival> ArrivalRouteNumNavigation { get; set; }
        public virtual ICollection<Departure> DepartureLegNumNavigation { get; set; }
        public virtual ICollection<Departure> DepartureRouteNumNavigation { get; set; }
        public virtual ICollection<LegInstance> LegInstance { get; set; }
        public virtual ICollection<Provides> Provides { get; set; }
    }
}
