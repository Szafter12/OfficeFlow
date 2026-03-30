using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Desk> Desks { get; set; } = new();
    }
}
