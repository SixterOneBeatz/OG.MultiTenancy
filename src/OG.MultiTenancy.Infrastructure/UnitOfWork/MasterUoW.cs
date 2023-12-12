using OG.Multitenancy.Application.Common.Repositories;
using OG.Multitenancy.Application.Common.UnitOfWork;
using OG.Multitenancy.Infrastructure.Contexts;
using OG.Multitenancy.Infrastructure.Repositories;

namespace OG.Multitenancy.Infrastructure.UnitOfWork
{
    public class MasterUoW(MasterDbContext context) : BaseUoW<MasterDbContext>(context), IMasterUoW
    {
        private readonly MasterDbContext _context = context;
        public IOrganizationRepository OrganinzationRepository => new OrganizationRepository(_context);
    }
}
