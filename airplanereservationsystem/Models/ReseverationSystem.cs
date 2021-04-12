using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class ReseverationSystem
    {
        public ReseverationSystem()
        {
            Administrator = new HashSet<Administrator>();
            AirlineCompany = new HashSet<AirlineCompany>();
            Customer = new HashSet<Customer>();
            GetsInfoFrom = new HashSet<GetsInfoFrom>();
            Provides = new HashSet<Provides>();
            RunBy = new HashSet<RunBy>();
            Ticket = new HashSet<Ticket>();
        }

        public string CheckInStatus { get; set; }
        public string CustomerName { get; set; }
        public int? JobNo { get; set; }
        public int ReservationSystemId { get; set; }

        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<AirlineCompany> AirlineCompany { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<GetsInfoFrom> GetsInfoFrom { get; set; }
        public virtual ICollection<Provides> Provides { get; set; }
        public virtual ICollection<RunBy> RunBy { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
