using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFlow.DTOs.User
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(
            50,
            MinimumLength = 1,
            ErrorMessage = "Name must contain between 1 and 50 chars"
        )]
        public string First_name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(
            50,
            MinimumLength = 1,
            ErrorMessage = "Last name must contain between 1 and 50 chars"
        )]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }
    }
}
