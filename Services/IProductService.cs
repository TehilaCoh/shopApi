using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getAllProducts(string? desc,int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}