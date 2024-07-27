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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=tcp:quartile-test-store.database.windows.net,1433;Initial Catalog=quartile-test-store;Persist Security Info=False;User ID=michelm;Password=92908735aA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=5;");
        //    //base.OnConfiguring(optionsBuilder);
        //}
    }
}
