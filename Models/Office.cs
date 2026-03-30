using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OpeningHours { get; set; } = "{}";
        public OfficeAddress? Address { get; set; }
        public List<Desk> Desks { get; set; } = new();
    }
}
