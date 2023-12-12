using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.Multitenancy.API.Services;
using OG.Multitenancy.Application.Common.Services;
using OG.Multitenancy.Infrastructure.Contexts;
using static OG.Multitenancy.Application.Common.Constants.SettingsConsts;

namespace OG.Multitenancy.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MasterDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ADMIN_CS_KEY)));
            services.AddDbContext<OrganizationDbContext>();
            services.AddTransient<IDbCreatorService, DbCreatorService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ITenantService, TenantService>();
            return services;
        }
    }
}
