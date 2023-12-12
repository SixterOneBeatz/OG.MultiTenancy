using OG.Multitenancy.Application.Common.Repositories;

namespace OG.Multitenancy.Application.Common.UnitOfWork
{
    public interface IMasterUoW : IBaseUoW
    {
        IOrganizationRepository OrganinzationRepository { get; }
    }
}
