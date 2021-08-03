using Blazor.FurnitureStore.Repositories;
using Blazor.FurnitureStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("getbycategory/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategiry(int productCategoryId)
        {
            return await _productRepository.GetByCategory(productCategoryId);
        }
    }
}
