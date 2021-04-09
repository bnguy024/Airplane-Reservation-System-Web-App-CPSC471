﻿using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Provides = new HashSet<Provides>();
        }

        public string Amount { get; set; }
        public string ClassType { get; set; }
        public string Date { get; set; }
        public string DateIssued { get; set; }
        public int? LegNum { get; set; }
        public int ReservationSystemId { get; set; }
        public int? SeatNum { get; set; }
        public int TicketNumber { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual ICollection<Provides> Provides { get; set; }
    }
}
