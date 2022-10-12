using Microsoft.EntityFrameworkCore;
using Persistence.DTOs;

namespace Persistence
{
    public class BichasDbContext : DbContext
    {
        public BichasDbContext(DbContextOptions<BichasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BichasDbContext).Assembly);
        }

        public DbSet<Mesas> Mesas { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
    }
}