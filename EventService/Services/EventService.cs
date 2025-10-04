using EventService.Models;
using EventService.Models.dtos;
using EventService.Repositories;
namespace EventService.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository) => _eventRepository = eventRepository;

        public async Task<Event> Add(CreateEventDto newEvent)
        {
            var eventToAdd = new Event
            {
                Id = Guid.NewGuid(),
                Title = newEvent.Title,
                Date = newEvent.Date,
                Capacity = newEvent.Capacity
            };
            await _eventRepository.Add(eventToAdd);
            return eventToAdd;
        }
        public async Task<bool> Delete(Guid id)
        {
            var existingEvent = await _eventRepository.GetById(id);
            if (existingEvent == null)
            {
                return false;
            }
            await _eventRepository.Delete(id);
            return true;
        }
        public async Task<IEnumerable<Event>> GetAll() => await _eventRepository.GetAll();
        public async Task<Event?> GetById(Guid id) => await _eventRepository.GetById(id);
        public async Task<bool> Update(Guid id, UpdateEventDto updatedEvent)
        {
            var existingEvent = await _eventRepository.GetById(id);
            if (existingEvent == null)
            {
                return false;
            }
            existingEvent.Title = updatedEvent.Title;
            existingEvent.Date = updatedEvent.Date;
            existingEvent.Capacity = updatedEvent.Capacity;
            await _eventRepository.Update(existingEvent);
            return true;
        }
    }
}