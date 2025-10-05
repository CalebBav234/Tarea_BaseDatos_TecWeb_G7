using EventService.Models;
using EventService.Data;
using Microsoft.EntityFrameworkCore;
namespace EventService.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Event newEvent)
        {
            await _context.Events.AddAsync(newEvent);
        }
        public async Task Delete(Guid id)
        {
            var eventToDelete = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
            }

        }
        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }
        public async Task<Event?> GetById(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Update(Event updatedEvent)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == updatedEvent.Id);
            if (existingEvent != null)
            {
                existingEvent.Title = updatedEvent.Title;
                existingEvent.Date = updatedEvent.Date;
                existingEvent.Capacity = updatedEvent.Capacity;
            }
        }
    }
}
