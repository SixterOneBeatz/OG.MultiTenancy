using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OG.Multitenancy.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
