using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class GoesTo
    {
        public string AirportCode { get; set; }
        public int UserId { get; set; }

        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
