using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Application.Common.Repositories
{
    public interface IOrganizationRepository
    {
        Task<OrganizationDom> Create(OrganizationDom organization);

        Task<bool> Exist(string name);
    }
}
