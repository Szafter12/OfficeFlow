using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.DTOs.Office
{
    public record OfficeDto(int Id, string Name, string OpeningHours, OfficeAddressDto? Address);
}
