using EventService.Data;
using EventService.Models;
using Microsoft.EntityFrameworkCore;

namespace EventService.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AppDbContext _context;
        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Guest newGuest)
        {
            await _context.AddAsync(newGuest);
        }

        public async Task Delete(Guid id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.id == id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
            }

        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            return await _context.Guests.FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task Update(Guest updateGuest)
        {
            var existing = await _context.Guests.FirstOrDefaultAsync(e => e.id == updateGuest.id);
            if (existing != null)
            {
               existing.id = updateGuest.id;
               existing.Fullname = updateGuest.Fullname;
               existing.Confirmed = updateGuest.Confirmed;
            }
        }
    }
}
