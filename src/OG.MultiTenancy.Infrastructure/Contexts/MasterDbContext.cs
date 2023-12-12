using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Infrastructure.Contexts
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options) { }
        public DbSet<OrganizationDom> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationDom>().Property(x => x.Id).UseIdentityColumn();
        }
    }
}
