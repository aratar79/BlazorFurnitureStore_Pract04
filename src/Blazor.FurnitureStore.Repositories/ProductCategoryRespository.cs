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
    public class ProductCategoryRespository : IProductCategoryRespository
    {
        private readonly IDbConnection _dbConneciton;
        public ProductCategoryRespository(IDbConnection dbConneciton)
        {
            _dbConneciton = dbConneciton;
        }
        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = @"SELECT Id as Id, Name as Name
                        FROM ProductCategories";

            return await _dbConneciton.QueryAsync<ProductCategory>(sql, new { });
        }
    }
}
