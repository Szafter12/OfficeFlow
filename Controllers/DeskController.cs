using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFlow.DTOs.Desk;
using OfficeFlow.Enums;
using OfficeFlow.Interfaces;

namespace OfficeFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeskController : ControllerBase
    {
        private readonly IDeskService _deskService;

        public DeskController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpGet("{officeId:int}")]
        public async Task<ActionResult<IEnumerable<DeskDto>>> GetAllByOffice(int officeId)
        {
            var desks = await _deskService.GetAllByOfficeAsync(officeId);
            return Ok(desks);
        }

        [HttpPost]
        public async Task<ActionResult<DeskDto>> Create([FromBody] DeskDto dto)
        {
            var createdDesk = await _deskService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetAllByOffice),
                new { officeId = createdDesk.OfficeId },
                createdDesk
            );
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] DeskStatus status)
        {
            try
            {
                await _deskService.UpdateStatusAsync(id, status);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Desk with ID {id} not found.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deskService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Desk with ID {id} not found.");
            }
        }
    }
}
