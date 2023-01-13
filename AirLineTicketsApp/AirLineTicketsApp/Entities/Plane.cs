using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Plane
    {
        public Plane()
        {
            this.Flights = new HashSet<Flight>();

        }
        public int Id { get; set; }
        public int PlaneId { get; set; }

        public string PlaneModel { get; set; }

        public string PlanePhoto { get; set; }

        public double HandLuggageVolume { get; set; }

        public bool Bar { get; set; }

        public int CountPassengerSeats { get; set; }

        public ICollection<Flight> Flights { get; set; }

    }
}
