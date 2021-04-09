using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class RunBy
    {
        public int AdminId { get; set; }
        public int ReservationSystemId { get; set; }

        public virtual Administrator Admin { get; set; }
        public virtual ReseverationSystem ReservationSystem { get; set; }
    }
}
