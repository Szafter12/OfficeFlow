using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        public async Task<List<AvailableTermDto>> GetAvailableTermsAsync(int deskId, DateTime date)
        {
            var desk = await _context
                .Desks.Include(d => d.Office)
                .FirstOrDefaultAsync(d => d.Id == deskId);

            if (desk == null)
                throw new Exception("Desk not found");

            var hours = JsonSerializer.Deserialize<OpeningHours>(desk.Office.OpeningHours);
            string todayHours = hours?.GetForDay(date.DayOfWeek) ?? "Closed";

            if (todayHours == "Closed")
                return new List<AvailableTermDto>();

            var times = todayHours.Split('-');
            var officeStart = date.Date.Add(TimeSpan.Parse(times[0]));
            var officeEnd = date.Date.Add(TimeSpan.Parse(times[1]));

            var takenReservations = await _context
                .Reservations.Where(r =>
                    r.Desk_id == deskId
                    && r.reservationStatus != ReservationStatus.Canceled
                    && r.Start_date < officeEnd
                    && r.End_date > officeStart
                )
                .OrderBy(r => r.Start_date)
                .ToListAsync();

            var availableTerms = new List<AvailableTermDto>();
            var currentCursor = officeStart;

            foreach (var res in takenReservations)
            {
                if (res.Start_date > currentCursor)
                {
                    availableTerms.Add(new AvailableTermDto(currentCursor, res.Start_date));
                }
                currentCursor = res.End_date > currentCursor ? res.End_date : currentCursor;
            }

            if (currentCursor < officeEnd)
            {
                availableTerms.Add(new AvailableTermDto(currentCursor, officeEnd));
            }

            return availableTerms;
        }

        public async Task<List<OfficeOccupancyView>> GetGlobalOccupancyAsync()
        {
            return await _context.Set<OfficeOccupancyView>().ToListAsync();
        }

        public async Task<List<UserReservationHistoryView>> GetUserHistory(int userId)
        {
            return await _context
                .Set<UserReservationHistoryView>()
                .Where(x => x.User_id == userId)
                .ToListAsync();
        }

        public async Task ArchiveOldReservationsAsync()
        {
            await _context.Database.ExecuteSqlRawAsync("CALL \"ArchiveOldReservations\"()");
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
