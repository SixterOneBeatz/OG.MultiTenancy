using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Application.Common.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Organization> Create(Organization organization);

        Task<bool> Exist(string name);
    }
}
