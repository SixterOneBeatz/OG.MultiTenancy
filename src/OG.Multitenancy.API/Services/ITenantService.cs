using OG.Multitenancy.API.Domain;

namespace OG.Multitenancy.API.Services
{
    public interface ITenantService
    {
        string GetTenantConnection();
    }
}
