using EventService.Models;

namespace EventService.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add(Guest newGuest);
        Task Update(Guest updateGuest);
        Task Delete(Guid id);
    }
}
