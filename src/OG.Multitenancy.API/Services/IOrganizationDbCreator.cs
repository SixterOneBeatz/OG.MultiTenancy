using OG.Multitenancy.API.Domain;

namespace OG.Multitenancy.API.Services
{
    public interface IOrganizationDbCreator
    {
        Task Create(Organization organization);
    }
}
