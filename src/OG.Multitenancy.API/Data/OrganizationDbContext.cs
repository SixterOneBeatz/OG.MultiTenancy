using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.API.Domain;
using OG.Multitenancy.API.Services;

namespace OG.Multitenancy.API.Data
{
    public class OrganizationDbContext(DbContextOptions<OrganizationDbContext> options, ITenantService tenantService) : DbContext(options)
    {
        private readonly ITenantService _tenantService = tenantService;
        public DbSet<Product> Products { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(16,2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_tenantService.GetTenantConnection());
        }
    }
}
