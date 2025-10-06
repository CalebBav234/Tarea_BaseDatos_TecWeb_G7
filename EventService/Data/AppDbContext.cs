using EventService.Models;
using Microsoft.EntityFrameworkCore;

namespace EventService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Guest> Guests => Set<Guest>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired();
                e.Property(x => x.Date).IsRequired();
                e.Property(x => x.Capacity).IsRequired();
            });

            modelBuilder.Entity<Guest>(g =>
            {
                g.HasKey(x => x.id);
                g.Property(x=>x.Fullname).IsRequired();
                g.Property(x=>x.Confirmed).IsRequired().HasDefaultValue(false);
            });
        }
    }
}