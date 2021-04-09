using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class User
    {
        public User()
        {
            Administrator = new HashSet<Administrator>();
            Customer = new HashSet<Customer>();
            GoesTo = new HashSet<GoesTo>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<GoesTo> GoesTo { get; set; }
    }
}
