using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airplanereservationsystem.Models
{
    public class ArrivalDeparture
    {
        public List<Arrival> arrivals { get; set; }
        public List<Departure> departures { get; set; }
    }
}
