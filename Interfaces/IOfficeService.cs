using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.Office;

namespace OfficeFlow.Interfaces
{
    public interface IOfficeService
    {
        Task<IEnumerable<OfficeDto>> GetAllAsync();
        Task<OfficeDto> GetByIdAsync(int id);
        Task<OfficeDto> CreateAsync(OfficeDto dto);
        Task UpdateAsync(int id, OfficeDto dto);
        Task DeleteAsync(int id);
    }
}
