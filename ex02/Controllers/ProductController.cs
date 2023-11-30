using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ex02.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productServices;

        public ProductController(IProductService _productServices) {

            productServices = _productServices;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery] string? desc,  int? minPrice,
            int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> allProducts = await productServices.getAllProducts(desc, minPrice, maxPrice, categoryIds);
            return allProducts;
        }

    }
}
