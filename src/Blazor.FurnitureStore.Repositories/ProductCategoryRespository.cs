using Blazor.FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Repositories
{
    public class ProductCategoryRespository : IProductCategoryRespository
    {
        private readonly IDbConnection _dbConneciton;
        public ProductCategoryRespository(IDbConnection dbConneciton)
        {
            _dbConneciton = dbConneciton;
        }
        public Task<IEnumerable<ProductCategory>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
