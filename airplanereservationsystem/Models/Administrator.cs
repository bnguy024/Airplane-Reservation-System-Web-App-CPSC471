using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Administrator
    {
        public int UserId { get; set; }
        public int AdminId { get; set; }
        public int ReservationSystemId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual User User { get; set; }
        public virtual AccessTo AccessTo { get; set; }
        public virtual RunBy RunBy { get; set; }
    }
}
