using AutoMapper;
using MediatR;
using OG.Multitenancy.Application.Common.DTOs;
using OG.Multitenancy.Application.Common.UnitOfWork;

namespace OG.Multitenancy.Application.Features.Product.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDTO>> { }

    public class GetProductsQueryHandler(IOrganizationUoW organizationUnitOfWork, IMapper mapper) : IRequestHandler<GetProductsQuery, List<ProductDTO>>
    {
        private readonly IOrganizationUoW _organizationUnitOfWork = organizationUnitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await this._organizationUnitOfWork.ProductRepository.GetProducts();

            var result = this._mapper.Map<List<ProductDTO>>(products);

            return result;
        }
    }
}
