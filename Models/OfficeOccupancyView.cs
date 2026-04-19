using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class OfficeOccupancyView
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; } = string.Empty;
        public int TotalDesks { get; set; }
        public int CurrentlyOccupied { get; set; }
        public decimal OccupancyRate { get; set; }
    }
}
