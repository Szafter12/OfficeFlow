using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.Models
{
    public class OfficeAddress
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public int OfficeId { get; set; }
        public Office Office { get; set; } = null!;
    }
}
