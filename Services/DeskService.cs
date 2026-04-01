using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.DTOs.Desk;
using OfficeFlow.Enums;
using OfficeFlow.Interfaces;
using OfficeFlow.Models;

namespace OfficeFlow.Services
{
    public class DeskService : IDeskService
    {
        private readonly ApplicationDbContext _context;

        public DeskService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<DeskDto>> GetAllByOfficeAsync(int officeId) =>
            await _context
                .Desks.Where(d => d.Office_id == officeId)
                .Select(d => new DeskDto(d.Id, d.Type, d.Price, d.Status, d.Office_id))
                .ToListAsync();

        public async Task<DeskDto> CreateAsync(DeskDto dto)
        {
            var desk = new Desk
            {
                Type = dto.Type,
                Price = dto.Price,
                Status = dto.Status,
                Office_id = dto.OfficeId,
            };
            _context.Desks.Add(desk);
            await _context.SaveChangesAsync();
            return dto with { Id = desk.Id };
        }

        public async Task UpdateStatusAsync(int id, DeskStatus status)
        {
            var desk = await _context.Desks.FindAsync(id) ?? throw new KeyNotFoundException();
            desk.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var desk = await _context.Desks.FindAsync(id) ?? throw new KeyNotFoundException();
            _context.Desks.Remove(desk);
            await _context.SaveChangesAsync();
        }
    }
}
