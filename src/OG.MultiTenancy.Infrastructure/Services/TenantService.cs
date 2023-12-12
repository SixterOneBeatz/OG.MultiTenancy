using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OG.Multitenancy.Application.Common.Services;
using OG.Multitenancy.Domain;
using OG.Multitenancy.Infrastructure.Contexts;
using static OG.Multitenancy.Application.Common.Constants.GlobalConsts;
using static OG.Multitenancy.Application.Common.Constants.SettingsConsts;

namespace OG.Multitenancy.Infrastructure.Services
{
    public class TenantService(MasterDbContext masterDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : ITenantService
    {
        private readonly MasterDbContext _masterDbContext = masterDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IConfiguration _configuration = configuration;
        public string GetTenantConnection()
        {
            Organization organization = null;
            string connection = this._configuration.GetConnectionString(DEFAULT_CS_KEY);

            if (this._httpContextAccessor.HttpContext.Request.Headers.TryGetValue(TENANT_HEADER_KEY, out var values))
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
