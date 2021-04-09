using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class Provides
    {
        public int ReservationSystemId { get; set; }
        public int TicketNumber { get; set; }
        public int LegNumber { get; set; }

        public virtual FlightLeg LegNumberNavigation { get; set; }
        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual Ticket TicketNumberNavigation { get; set; }
    }
}
