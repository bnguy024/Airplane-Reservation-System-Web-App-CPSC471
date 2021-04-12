using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Administrator
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int ReservationSystemId { get; set; }
        public int UserId { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual User User { get; set; }
        public virtual AccessTo AccessTo { get; set; }
        public virtual RunBy RunBy { get; set; }
    }
}
