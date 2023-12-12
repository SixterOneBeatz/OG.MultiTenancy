using OG.Multitenancy.Application.Common.Repositories;

namespace OG.Multitenancy.Application.Common.UnitOfWork
{
    public interface IOrganizationUoW : IBaseUoW
    {
        IProductRepository ProductRepository { get; }
    }
}
