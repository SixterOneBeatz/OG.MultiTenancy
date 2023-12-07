using Microsoft.AspNetCore.Http;
using OG.Multitenancy.API.Data;
using OG.Multitenancy.API.Domain;

namespace OG.Multitenancy.API.Services
{
    public class TenantService(MasterDbContext masterDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : ITenantService
    {
        private readonly MasterDbContext _masterDbContext = masterDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IConfiguration _configuration = configuration;
        public string GetTenantConnection()
        {
            Organization organization = null;
            string connection = this._configuration.GetConnectionString("OrganizationDefault");

            if (this._httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Tenant", out var values))
            {
                organization = this._masterDbContext.Organizations.FirstOrDefault(x => x.Name == values.FirstOrDefault());
            }

            if (organization is not null)
            {
                connection = organization.ConnectionString;
            }

            return connection;
        }
    }
}
