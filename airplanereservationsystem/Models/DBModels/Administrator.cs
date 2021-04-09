using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class Administrator
    {
        public Administrator()
        {
            AccessTo = new HashSet<AccessTo>();
            RunBy = new HashSet<RunBy>();
        }

        public int UserId { get; set; }
        public int AdminId { get; set; }
        public int ReservationSystemId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AccessTo> AccessTo { get; set; }
        public virtual ICollection<RunBy> RunBy { get; set; }
    }
}
