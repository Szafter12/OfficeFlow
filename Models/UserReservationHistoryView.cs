using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class UserReservationHistoryView
    {
        public int ReservationId { get; set; }
        public int User_id { get; set; }
        public string First_name { get; set; }
        public string DeskNumber { get; set; }
        public string OfficeName { get; set; }
        public DateTime Start_date { get; set; }
        public decimal Final_price { get; set; }
        public double DurationHours { get; set; }
    }
}
