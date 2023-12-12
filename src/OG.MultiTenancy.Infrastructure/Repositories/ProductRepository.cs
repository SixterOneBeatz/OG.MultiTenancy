using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Application.Common.Repositories;
using OG.Multitenancy.Domain;
using OG.Multitenancy.Infrastructure.Contexts;

namespace OG.Multitenancy.Infrastructure.Repositories
{
    public class ProductRepository(OrganizationDbContext organizationDbContext) : IProductRepository
    {
        private readonly OrganizationDbContext _organizationDbContext = organizationDbContext;
        public async Task<List<ProductDom>> GetProducts()
        {
            return await this._organizationDbContext.Products.ToListAsync();
        }
    }
}
