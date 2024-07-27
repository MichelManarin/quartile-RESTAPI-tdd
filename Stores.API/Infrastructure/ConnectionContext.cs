using Microsoft.EntityFrameworkCore;
using Stores.API.Models;

namespace Stores.API.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ConnectionContext(DbContextOptions<ConnectionContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .OwnsOne(c => c.Address);
            modelBuilder.Entity<Store>()
                .OwnsOne(c => c.Address);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
