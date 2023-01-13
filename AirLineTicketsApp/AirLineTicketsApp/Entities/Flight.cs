using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        

        public string FirstDestination { get; set; }

        public string LastDestination { get; set; }

        public DateTime Takeoff { get; set; }

        public DateTime Landing { get; set; }

        [ForeignKey("Plane")]
        public int  PlaneId { get; set; }

        public Plane Plane { get; set; }

        public double TicketPrice { get; set; }

        public double DiscountProcent { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
