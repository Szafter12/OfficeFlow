using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFlow.DTOs.Amenity;
using OfficeFlow.Interfaces;

namespace OfficeFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenityController : ControllerBase
    {
        private IAmenityService _service;

        public AmenityController(IAmenityService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AmenityDto>>> GetAllAmenities()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AmenityDto>> GetAmenity(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<AmenityDto>> CreateAmenity(AmenityDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAmenity), new { id = dto.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AmenityDto>> UpdateAmenity(int id, AmenityDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AmenityDto>> DeleteAmenity(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
