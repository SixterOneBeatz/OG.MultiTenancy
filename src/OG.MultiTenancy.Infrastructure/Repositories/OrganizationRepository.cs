using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Application.Common.Repositories;
using OG.Multitenancy.Domain;
using OG.Multitenancy.Infrastructure.Contexts;

namespace OG.Multitenancy.Infrastructure.Repositories
{
    public class OrganizationRepository(MasterDbContext masterDbContext) : IOrganizationRepository
    {
        private readonly MasterDbContext _masterDbContext = masterDbContext;

        public async Task<Organization> Create(Organization organization)
        {
            var created = await this._masterDbContext.AddAsync(organization);

            return created.Entity;
        }

        public async Task<bool> Exist(string name)
        {
            return await this._masterDbContext.Organizations.AnyAsync(org => org.Name == name);
        }
    }
}
