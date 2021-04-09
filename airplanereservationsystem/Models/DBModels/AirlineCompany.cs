using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class AirlineCompany
    {
        public string Name { get; set; }
        public int ReservationSystemId { get; set; }
        public string HqCity { get; set; }
        public string AirlineCode { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
    }
}
