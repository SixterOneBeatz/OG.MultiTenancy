using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.API.Domain;

namespace OG.Multitenancy.API.Data
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options) { }

        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().Property(x => x.Id).UseIdentityColumn();
        }
    }
}
