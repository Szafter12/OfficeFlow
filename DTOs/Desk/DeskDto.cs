using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.Enums;

namespace OfficeFlow.DTOs.Desk
{
    public record DeskDto(int Id, DeskType Type, decimal Price, Status Status, int OfficeId);
}
