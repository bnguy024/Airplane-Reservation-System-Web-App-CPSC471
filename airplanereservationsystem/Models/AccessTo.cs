using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class AccessTo
    {
        public int AdminId { get; set; }
        public int CustomerId { get; set; }

        public virtual Administrator Admin { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
