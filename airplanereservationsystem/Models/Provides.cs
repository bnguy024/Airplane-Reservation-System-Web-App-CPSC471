using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Provides
    {
        public int LegNumber { get; set; }
        public int ReservationSystemId { get; set; }
        public int TicketNumber { get; set; }

        public virtual FlightLeg LegNumberNavigation { get; set; }
        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual Ticket TicketNumberNavigation { get; set; }
    }
}
