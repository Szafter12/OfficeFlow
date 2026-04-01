using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.Desk;
using OfficeFlow.Enums;

namespace OfficeFlow.Interfaces
{
    public interface IDeskService
    {
        Task<IEnumerable<DeskDto>> GetAllByOfficeAsync(int officeId);
        Task<DeskDto> CreateAsync(DeskDto dto);
        Task UpdateStatusAsync(int id, DeskStatus status);
        Task DeleteAsync(int id);
    }
}
