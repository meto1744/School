using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Reservation
    {

        public int Id { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        
        public Client Client{ get; set; }

        [ForeignKey("Flight")]

        public int FlightId { get; set; }

        public Flight Flight { get; set; }

        public DateTime TicketReservation { get; set; }

        public int NumberOfTickets { get; set; }
    }
}
