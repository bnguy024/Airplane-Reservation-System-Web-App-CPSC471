using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models
{
    public partial class Airplane
    {
        public Airplane()
        {
            AirplaneTypeModelTypeNavigation = new HashSet<AirplaneType>();
            Flies = new HashSet<Flies>();
            GetsInfoFrom = new HashSet<GetsInfoFrom>();
            OwnsAirlineCompanyNameNavigation = new HashSet<Owns>();
            OwnsAirplane = new HashSet<Owns>();
        }

        public string AirlineCompanyName { get; set; }
        public int AirplaneId { get; set; }
        public string ModelType { get; set; }
        public string Pilot { get; set; }
        public int? TotalNumSeats { get; set; }

        public virtual AirplaneType AirplaneTypeAirplane { get; set; }
        public virtual ICollection<AirplaneType> AirplaneTypeModelTypeNavigation { get; set; }
        public virtual ICollection<Flies> Flies { get; set; }
        public virtual ICollection<GetsInfoFrom> GetsInfoFrom { get; set; }
        public virtual ICollection<Owns> OwnsAirlineCompanyNameNavigation { get; set; }
        public virtual ICollection<Owns> OwnsAirplane { get; set; }
    }
}
