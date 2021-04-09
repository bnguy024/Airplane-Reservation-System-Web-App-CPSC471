using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class Customer
    {
        public Customer()
        {
            AccessTo = new HashSet<AccessTo>();
        }

        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int ReservationSystemId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNum { get; set; }

        public virtual ReseverationSystem ReservationSystem { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AccessTo> AccessTo { get; set; }
    }
}
