using Microsoft.EntityFrameworkCore;
using UDPListener.Data.Models;

namespace UDPListener.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IPAddress> IPAddresses { get; set; }
        public DbSet<Message> Messages { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                  
        }

    }
}
