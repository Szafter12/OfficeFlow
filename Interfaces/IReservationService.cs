using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.Reservation;
using OfficeFlow.Models;

namespace OfficeFlow.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> CreateReservationAsync(ReservationDto dto);
        Task<List<AvailableTermDto>> GetAvailableTermsAsync(int deskId, DateTime date);
        Task ArchiveOldReservationsAsync();
        Task<List<OfficeOccupancyView>> GetGlobalOccupancyAsync();
        Task<List<UserReservationHistoryView>> GetUserHistory(int userId);
    }
}
