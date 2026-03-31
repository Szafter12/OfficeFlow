using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFlow.DTOs.Office;
using OfficeFlow.Interfaces;

namespace OfficeFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficesController(IOfficeService officeService) => _officeService = officeService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeDto>>> GetAll() =>
            Ok(await _officeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeDto>> Get(int id) =>
            Ok(await _officeService.GetByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult<OfficeDto>> Create(OfficeDto dto)
        {
            var result = await _officeService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OfficeDto dto)
        {
            await _officeService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _officeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
