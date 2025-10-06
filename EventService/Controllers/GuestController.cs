using EventService.EventService.Services;
using EventService.Models.dtos;
using EventService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventService.EventService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {

        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guest = await _guestService.GetAll();
            return Ok(guest);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var guest = await _guestService.GetById(id);
            return guest is null ? NotFound(new { error = "Guest not found", status = 404 }) : Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var guest = await _guestService.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = guest.id }, guest);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGuestDto updatedGuest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);

            }
            var result = await _guestService.Update(id, updatedGuest);
            if (!result)
            {
                return NotFound(new { error = "Guest not found", status = 404 });

            }
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _guestService.Delete(id);
            return result ? NoContent() : NotFound(new { error = "Guest not found", status = 404 });
        }
    }
}
