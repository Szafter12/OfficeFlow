using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.Reservation;

namespace OfficeFlow.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> CreateReservationAsync(ReservationDto dto);
        Task<bool> IsDeskAvailable(int deskId);
    }
}
