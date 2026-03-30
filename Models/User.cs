using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string First_name { get; set; } = string.Empty;
        public required string Last_name { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public List<Reservation> Reservations { get; set; } = new();
    }
}
