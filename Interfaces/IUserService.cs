using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFlow.DTOs.User;
using OfficeFlow.Models;

namespace OfficeFlow.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> Add(UserDto user);
    }
}
