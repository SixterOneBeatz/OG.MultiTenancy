using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Application.Common.Services;
using OG.Multitenancy.Domain;
using OG.Multitenancy.Infrastructure.Contexts;

namespace OG.Multitenancy.API.Services
{
    public class DbCreatorService(OrganizationDbContext organizationDbContext, IHttpContextAccessor httpContextAccessor) : IDbCreatorService
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
