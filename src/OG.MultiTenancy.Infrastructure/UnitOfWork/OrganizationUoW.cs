
using OG.Multitenancy.Application.Common.Repositories;
using OG.Multitenancy.Application.Common.UnitOfWork;
using OG.Multitenancy.Infrastructure.Contexts;
using OG.Multitenancy.Infrastructure.Repositories;

namespace OG.Multitenancy.Infrastructure.UnitOfWork
{
    public class OrganizationUoW(OrganizationDbContext context) : BaseUoW<OrganizationDbContext>(context), IOrganizationUoW
    {
        private readonly OrganizationDbContext _context = context;
        public IProductRepository ProductRepository => new ProductRepository(_context);
    }
}
