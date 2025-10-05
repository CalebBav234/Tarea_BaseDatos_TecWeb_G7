using EventService.Models.dtos;
using EventService.Services;
using Microsoft.AspNetCore.Mvc;
namespace EventService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAll();
            return Ok(events);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ev = await _eventService.GetById(id);
            return ev is null ? NotFound(new { error = "Event not found", status = 404 }) : Ok(ev); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto newEvent)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var createdEvent = await _eventService.Add(newEvent);
            return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventDto updatedEvent)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);

            }
            var result = await _eventService.Update(id, updatedEvent);
            if (!result)
            {
                return NotFound(new { error = "Event not found", status = 404 });

            }
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _eventService.Delete(id);
            return result ? NoContent() : NotFound(new { error = "Event not found", status = 404 });
        }
     }
}