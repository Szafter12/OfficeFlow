using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.Amenity;

namespace OfficeFlow.Interfaces
{
    public interface IAmenityService
    {
        Task<IEnumerable<AmenityDto>> GetAllAsync();
        Task<AmenityDto> GetByIdAsync(int id);
        Task<AmenityDto> CreateAsync(AmenityDto dto);
        Task UpdateAsync(int id, AmenityDto dto);
        Task DeleteAsync(int id);
    }
}
