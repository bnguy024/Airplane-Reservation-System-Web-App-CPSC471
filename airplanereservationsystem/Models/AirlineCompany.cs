using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class AirlineCompany
    {
        public string AirlineCode { get; set; }
        public string HqCity { get; set; }
        public string Name { get; set; }
        public int ReservationSystemId { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
    }
}
