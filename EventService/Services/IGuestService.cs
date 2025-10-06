using EventService.Models.dtos;
using EventService.Models;

namespace EventService.EventService.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task<Guest> Add(CreateGuestDto guest);
        Task<bool> Update(Guid id, UpdateGuestDto update);
        Task<bool> Delete(Guid id);
    }
}
