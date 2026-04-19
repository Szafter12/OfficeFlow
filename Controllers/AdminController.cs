using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFlow.DTOs.Reservation;
using OfficeFlow.Interfaces;
using OfficeFlow.Models;

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

        [HttpGet("occupancy")]
        public async Task<ActionResult<List<OfficeOccupancyView>>> GetOfficeOccupancy()
        {
            var stats = await _reservationService.GetGlobalOccupancyAsync();

            if (stats == null)
            {
                return NoContent();
            }

            return Ok(stats);
        }

        [HttpGet("{userId}/history")]
        public async Task<ActionResult<List<UserReservationHistoryView>>> GetUserHistory(int userId)
        {
            var history = await _reservationService.GetUserHistory(userId);

            if (history == null)
            {
                return Ok(new List<UserReservationHistoryView>());
            }

            return Ok(history);
        }
    }
}
