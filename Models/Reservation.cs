using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Desk_id { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Updated_at { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = null!;
        public Desk Desk { get; set; } = null!;
    }
}
