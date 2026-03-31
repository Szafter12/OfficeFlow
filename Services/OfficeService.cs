using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.DTOs.Office;
using OfficeFlow.Interfaces;
using OfficeFlow.Models;

namespace OfficeFlow.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly ApplicationDbContext _context;

        public OfficeService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<OfficeDto>> GetAllAsync()
        {
            return await _context
                .Offices.Include(o => o.Address)
                .Select(o => new OfficeDto(
                    o.Id,
                    o.Name,
                    o.OpeningHours,
                    o.Address == null
                        ? null
                        : new OfficeAddressDto(
                            o.Address.AddressLine1,
                            o.Address.AddressLine2,
                            o.Address.City,
                            o.Address.Town,
                            o.Address.PostalCode
                        )
                ))
                .ToListAsync();
        }

        public async Task<OfficeDto> GetByIdAsync(int id)
        {
            var o =
                await _context.Offices.Include(o => o.Address).FirstOrDefaultAsync(o => o.Id == id)
                ?? throw new KeyNotFoundException();

            return new OfficeDto(
                o.Id,
                o.Name,
                o.OpeningHours,
                o.Address == null
                    ? null
                    : new OfficeAddressDto(
                        o.Address.AddressLine1,
                        o.Address.AddressLine2,
                        o.Address.City,
                        o.Address.Town,
                        o.Address.PostalCode
                    )
            );
        }

        public async Task<OfficeDto> CreateAsync(OfficeDto dto)
        {
            var office = new Office
            {
                Name = dto.Name,
                OpeningHours = dto.OpeningHours,
                Address =
                    dto.Address == null
                        ? null
                        : new OfficeAddress
                        {
                            AddressLine1 = dto.Address.AddressLine1,
                            City = dto.Address.City,
                            Town = dto.Address.Town,
                            PostalCode = dto.Address.PostalCode,
                        },
            };
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
            return dto with { Id = office.Id };
        }

        public async Task UpdateAsync(int id, OfficeDto dto)
        {
            var office =
                await _context.Offices.Include(o => o.Address).FirstOrDefaultAsync(o => o.Id == id)
                ?? throw new KeyNotFoundException();

            office.Name = dto.Name;
            office.OpeningHours = dto.OpeningHours;

            if (dto.Address != null)
            {
                if (office.Address == null)
                    office.Address = new OfficeAddress();
                office.Address.City = dto.Address.City;
                office.Address.PostalCode = dto.Address.PostalCode;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var office = await _context.Offices.FindAsync(id) ?? throw new KeyNotFoundException();
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
        }
    }
}
