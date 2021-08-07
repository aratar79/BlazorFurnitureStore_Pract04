using Blazor.FurnitureStore.Shared;
using Dapper;
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
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            var Sql = @"SELECT Id, Name, Price, CategoryId FROM Products WHERE CategoryId = @Id";
            var result = await _dbConneciton.QueryAsync<Product>(Sql, new { Id = productCategoryId });
            return result;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var Sql = @"SELECT Id, Name, Price, CategoryId AS ProductCategoryId FROM Products WHERE Id = @Id";
            var result = await _dbConneciton.QueryFirstOrDefaultAsync<Product>(Sql, new { Id = Id });
            return result;
        }
    }
}

