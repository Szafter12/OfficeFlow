using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.DTOs.Reservation;
using OfficeFlow.Enums;
using OfficeFlow.Exceptions;
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
            using var transaction = await _context.Database.BeginTransactionAsync(
                // Setting isolation level to serializable to prevent race condition
                System.Data.IsolationLevel.Serializable
            );

            try
            {
                bool isAvailable = await IsDeskAvailable(dto.deskId, dto.startDate, dto.endDate);

                if (!isAvailable)
                {
                    throw new DeskUnavailableException();
                }

                double hours = (dto.endDate - dto.startDate).TotalHours;
                decimal finalPrice = await CalculatePrice(dto.deskId, hours);

                var newReservation = new Reservation
                {
                    User_id = dto.userId,
                    Desk_id = dto.deskId,
                    Start_date = dto.startDate,
                    End_date = dto.endDate,
                    final_price = finalPrice,
                };

                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return dto with
                {
                    reservationId = newReservation.Id,
                };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new DeskUnavailableException();
            }
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

        private async Task<decimal> CalculatePrice(int deskId, double hours)
        {
            var desk = await _context.Desks.FirstOrDefaultAsync(d => d.Id == deskId);

            if (desk == null)
            {
                throw new KeyNotFoundException();
            }

            decimal pricePerHour = desk.Price;

            return pricePerHour * (decimal)hours;
        }
    }
}
