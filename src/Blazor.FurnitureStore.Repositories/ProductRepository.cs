using Blazor.FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConneciton;
        public ProductRepository(IDbConnection dbConneciton)
        {
            _dbConneciton = dbConneciton;
        }
        public Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
