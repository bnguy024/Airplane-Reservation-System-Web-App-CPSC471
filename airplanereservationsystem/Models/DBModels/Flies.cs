using System;
using System.Collections.Generic;

namespace airplanereservationsystem.Models.DBModels
{
    public partial class Flies
    {
        public int AirplaneId { get; set; }
        public int RouteNum { get; set; }

        public virtual Airplane Airplane { get; set; }
        public virtual AirplaneRoute RouteNumNavigation { get; set; }
    }
}
