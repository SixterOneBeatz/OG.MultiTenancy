using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Application.Common.Services
{
    public interface IDbCreatorService
    {
        Task Create(Organization organization);
    }
}
