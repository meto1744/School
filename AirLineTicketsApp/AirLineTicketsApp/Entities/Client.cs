using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Client
    {
        public Client()
        {
            this.Reservations = new HashSet<Reservation>();

        }
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Addres { get; set; }

        public ICollection<Reservation> Reservations { get; set; }


    }
}
