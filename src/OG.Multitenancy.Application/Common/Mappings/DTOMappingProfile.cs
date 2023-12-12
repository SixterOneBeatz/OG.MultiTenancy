using AutoMapper;
using OG.Multitenancy.Application.Common.DTOs;
using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Application.Common.Mappings
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<ProductDom, ProductDTO>().ReverseMap();
        }
    }
}
