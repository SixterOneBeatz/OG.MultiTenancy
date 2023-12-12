using MediatR;
using OG.Multitenancy.Application.Common.UnitOfWork;

namespace OG.Multitenancy.Application.Features.Product.Queries
{
    public class GetProductsQuery : IRequest<List<Domain.Product>> { }

    public class GetProductsQueryHandler(IOrganizationUoW organizationUnitOfWork) : IRequestHandler<GetProductsQuery, List<Domain.Product>>
    {
        private readonly IOrganizationUoW _organizationUnitOfWork = organizationUnitOfWork;

        public async Task<List<Domain.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await this._organizationUnitOfWork.ProductRepository.GetProducts();
        }
    }
}
