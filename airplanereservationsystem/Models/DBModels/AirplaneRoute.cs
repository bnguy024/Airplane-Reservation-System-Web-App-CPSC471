using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class AirplaneRoute
    {
        public AirplaneRoute()
        {
            Flies = new HashSet<Flies>();
        }

        public int RouteNum { get; set; }
        public string AirportCode { get; set; }
        public string Status { get; set; }
        public int? AmountOfTime { get; set; }

        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual ICollection<Flies> Flies { get; set; }
    }
}
