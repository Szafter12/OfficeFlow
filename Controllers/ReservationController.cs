using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFlow.DTOs.Reservation;
using OfficeFlow.Interfaces;

namespace OfficeFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation(ReservationDto dto)
        {
            var result = await _service.CreateReservationAsync(dto);

            return NoContent();
        }

        [HttpGet("available-terms")]
        public async Task<ActionResult<List<AvailableTermDto>>> GetAvailableTerms(
            [FromQuery] int deskId,
            [FromQuery] DateTime date
        )
        {
            var terms = await _service.GetAvailableTermsAsync(deskId, date);
            return Ok(terms);
        }
    }
}
