using EventService.Models;
using EventService.Models.dtos;
namespace EventService.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Add(CreateEventDto newEvent);
        Task<bool> Update(Guid id, UpdateEventDto updatedEvent);
        Task<bool> Delete(Guid id);
    }
}