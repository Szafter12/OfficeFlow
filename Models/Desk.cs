using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public enum DeskType
    {
        Desk,
        ConferenceRoom,
    }

    public enum Status
    {
        Active,
        Taken,
        Closed,
    }

    public class Desk
    {
        public int Id { get; set; }
        public DeskType Type { get; set; } = DeskType.Desk;
        public Decimal Price { get; set; }
        public Status Status { get; set; } = Status.Active;
        public int Office_id { get; set; }
        public Office Office { get; set; } = null!;
        public List<Reservation> Reservations { get; set; } = new();
        public List<Amenity> Amenities { get; set; } = new();
    }
}
