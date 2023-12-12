using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.Application.Common.Services;
using OG.Multitenancy.Domain;
using OG.Multitenancy.Infrastructure.Contexts;
using static OG.Multitenancy.Application.Common.Constants.GlobalConsts;

namespace OG.Multitenancy.Infrastructure.Services
{
    public class DbCreatorService(OrganizationDbContext organizationDbContext, IHttpContextAccessor httpContextAccessor) : IDbCreatorService
    {
        private readonly OrganizationDbContext _organizationDbContext = organizationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public async Task Create(Organization organization)
        {
            _httpContextAccessor.HttpContext.Request.Headers[TENANT_HEADER_KEY] = organization.Name;
            await this._organizationDbContext.Database.MigrateAsync();
        }
    }
}
