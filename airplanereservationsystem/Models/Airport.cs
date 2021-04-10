using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Airport
    {
        public Airport()
        {
            AirplaneRoute = new HashSet<AirplaneRoute>();
            Arrival = new HashSet<Arrival>();
            Departure = new HashSet<Departure>();
            GetsInfoFrom = new HashSet<GetsInfoFrom>();
            GoesTo = new HashSet<GoesTo>();
        }

        public string AirportCode { get; set; }
        public string City { get; set; }
        public string ProvinceState { get; set; }
        public string Country { get; set; }

        public virtual ICollection<AirplaneRoute> AirplaneRoute { get; set; }
        public virtual ICollection<Arrival> Arrival { get; set; }
        public virtual ICollection<Departure> Departure { get; set; }
        public virtual ICollection<GetsInfoFrom> GetsInfoFrom { get; set; }
        public virtual ICollection<GoesTo> GoesTo { get; set; }
    }
}
