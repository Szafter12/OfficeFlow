using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.DTOs.Office
{
    public record OfficeAddressDto(
        string AddressLine1,
        string AddressLine2,
        string City,
        string Town,
        string PostalCode
    );
}
