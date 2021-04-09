using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class AirplaneType
    {
        public int AirplaneId { get; set; }
        public string ModelType { get; set; }
        public int? MaxSeats { get; set; }
        public string Company { get; set; }

        public virtual Airplane Airplane { get; set; }
        public virtual Airplane ModelTypeNavigation { get; set; }
    }
}
