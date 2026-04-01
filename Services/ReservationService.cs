using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.DTOs.Reservation;
using OfficeFlow.Enums;
using OfficeFlow.Interfaces;
using OfficeFlow.Models;

namespace OfficeFlow.Services
{
    public class ReservationService : IReservationService
    {
        private ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReservationDto> CreateReservationAsync(ReservationDto dto)
        {
            bool isAvailable = await IsDeskAvailable(dto.deskId, dto.startDate, dto.endDate);

            if (!isAvailable)
            {
                throw new Exception("Desk is already taken");
            }

            var newReservation = new Reservation
            {
                User_id = dto.userId,
                Desk_id = dto.deskId,
                Start_date = dto.startDate,
                End_date = dto.endDate,
            };

            _context.Reservations.Add(newReservation);
            await _context.SaveChangesAsync();

            dto.reservationId = newReservation.Id;
        }

        private async Task<bool> IsDeskAvailable(int deskId, DateTime start, DateTime end)
        {
            bool isCollision = await _context.Reservations.AnyAsync(r =>
                r.Desk_id == deskId
                && r.Desk.Status == DeskStatus.Available
                && r.Start_date < end
                && r.End_date > start
            );

            return !isCollision;
        }
    }
}
