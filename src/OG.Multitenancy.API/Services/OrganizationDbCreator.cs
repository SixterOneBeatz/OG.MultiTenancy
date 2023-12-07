using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.API.Data;
using OG.Multitenancy.API.Domain;

namespace OG.Multitenancy.API.Services
{
    public class OrganizationDbCreator(OrganizationDbContext organizationDbContext, IHttpContextAccessor httpContextAccessor) : IOrganizationDbCreator
    {
        private readonly OrganizationDbContext _organizationDbContext = organizationDbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
        public async Task Create(Organization organization)
        {
            httpContextAccessor.HttpContext.Request.Headers["Tenant"] = organization.Name;
            await this._organizationDbContext.Database.MigrateAsync();
        }
    }
}
