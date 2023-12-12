using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Infrastructure.Contexts
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
