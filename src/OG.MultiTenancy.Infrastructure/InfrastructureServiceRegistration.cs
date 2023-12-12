using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.Multitenancy.Application.Common.Services;
using OG.Multitenancy.Application.Common.UnitOfWork;
using OG.Multitenancy.Infrastructure.Contexts;
using OG.Multitenancy.Infrastructure.Services;
using OG.Multitenancy.Infrastructure.UnitOfWork;
using static OG.Multitenancy.Application.Common.Constants.SettingsConsts;

namespace OG.Multitenancy.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MasterDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ADMIN_CS_KEY)), contextLifetime: ServiceLifetime.Transient);
            services.AddDbContext<OrganizationDbContext>(ServiceLifetime.Transient);
            services.AddTransient<IDbCreatorService, DbCreatorService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<IMasterUoW, MasterUoW>();
            services.AddTransient<IOrganizationUoW, OrganizationUoW>();

            return services;
        }
    }
}
