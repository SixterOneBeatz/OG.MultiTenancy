using OG.Multitenancy.Domain;

namespace OG.Multitenancy.Application.Common.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
    }
}
