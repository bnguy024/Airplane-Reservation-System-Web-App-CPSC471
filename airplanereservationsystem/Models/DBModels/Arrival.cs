using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class Arrival
    {
        public string AirportCode { get; set; }
        public int LegNum { get; set; }
        public int RouteNum { get; set; }
        public string ScheduleArrTime { get; set; }

        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual FlightLeg LegNumNavigation { get; set; }
        public virtual FlightLeg RouteNumNavigation { get; set; }
    }
}
