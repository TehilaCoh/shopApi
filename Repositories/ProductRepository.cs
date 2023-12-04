using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdoNet1Context _DbContext;
        public ProductRepository(AdoNet1Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _DbContext.Products.Where(Product =>
           (desc == null ? (true) : (Product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (Product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))
             .OrderBy(Product => Product.Price);

            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }
        public async Task<IEnumerable<Product>> getProductByCategory(int category)
        {
            return await _DbContext.Products.Where(a => a.CategoryId == category).ToListAsync();
        }

        //public async Task<Product> GetProductById(int ProductId) { 
        
            
        //}
    }

}
