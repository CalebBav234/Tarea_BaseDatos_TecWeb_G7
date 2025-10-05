using EventService.Models;
namespace EventService.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event newEvent);
        Task Update(Event updatedEvent);
        Task Delete(Guid id);

    }
}