using EventService.Models;
using EventService.Models.dtos;
using EventService.Repositories;

namespace EventService.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository) => _guestRepository = guestRepository;

        public async Task<Guest> Add(CreateGuestDto newGuest)
        {
            var guestToAdd = new Guest
            {
                id = Guid.NewGuid(),
                Fullname = newGuest.Fullname,
                Confirmed = newGuest.Confirmed

            };
            await _guestRepository.Add(guestToAdd);
            return guestToAdd;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _guestRepository.GetById(id);
            if (existing == null)
            {
                return false;
            }
            await _guestRepository.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _guestRepository.GetAll();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            return await _guestRepository.GetById(id);
        }

        public async Task<bool> Update(Guid id, UpdateGuestDto update)
        {
            var existing = await _guestRepository.GetById(id);
            if (existing == null)
            {
                return false;
            }
            existing.Fullname = update.Fullname;
            existing.Confirmed = update.Confirmed;
            await _guestRepository.Update(existing);
            return true;
        }
    }
}
