using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.Desk;
using OfficeFlow.DTOs.User;
using OfficeFlow.Enums;

namespace OfficeFlow.DTOs.Reservation
{
    public record ReservationDto(
        int reservationId,
        int userId,
        int deskId,
        ReservationStatus reservationStatus,
        DateTime startDate,
        DateTime endDate,
        UserDto? user,
        DeskDto? desk
    );
}
