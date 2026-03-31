using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.DTOs.Amenity;
using OfficeFlow.Interfaces;
using OfficeFlow.Models;

namespace OfficeFlow.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly ApplicationDbContext _context;

        public AmenityService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<AmenityDto>> GetAllAsync() =>
            await _context.Amenities.Select(a => new AmenityDto(a.Id, a.Name)).ToListAsync();

        public async Task<AmenityDto> GetByIdAsync(int id)
        {
            var a = await _context.Amenities.FindAsync(id) ?? throw new KeyNotFoundException();
            return new AmenityDto(a.Id, a.Name);
        }

        public async Task<AmenityDto> CreateAsync(AmenityDto dto)
        {
            var amenity = new Amenity { Name = dto.Name };
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
            return dto with { Id = amenity.Id };
        }

        public async Task UpdateAsync(int id, AmenityDto dto)
        {
            var amenity =
                await _context.Amenities.FindAsync(id) ?? throw new KeyNotFoundException();
            amenity.Name = dto.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var amenity =
                await _context.Amenities.FindAsync(id) ?? throw new KeyNotFoundException();
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
