using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.DTOs.User;
using OfficeFlow.Interfaces;
using OfficeFlow.Models;

namespace OfficeFlow.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _context
                .Users.Select(u => new UserDto
                {
                    UserId = u.Id,
                    First_name = u.First_name,
                    Last_name = u.Last_name,
                    Email = u.Email,
                })
                .ToListAsync();

            return users;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.Id,
                First_name = user.First_name,
                Last_name = user.Last_name,
                Email = user.Email,
            };
        }

        public async Task<UserDto> Add(UserDto user)
        {
            var exists = await _context.Users.AnyAsync(u => u.Email == user.Email);

            if (exists)
            {
                throw new Exception("Email already exist");
            }

            var newUser = new User
            {
                First_name = user.First_name,
                Last_name = user.Last_name,
                Email = user.Email,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            user.UserId = newUser.Id;
            return user;
        }
    }
}
