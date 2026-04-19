using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFlow.DTOs.Reservation;
using OfficeFlow.Interfaces;

namespace OfficeFlow.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IReservationService _reservationService;

        public AdminController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("archive")]
        public async Task<IActionResult> RunArchive()
        {
            await _reservationService.ArchiveOldReservationsAsync();
            return Ok(new { message = "Archiving success" });
        }
    }
}
