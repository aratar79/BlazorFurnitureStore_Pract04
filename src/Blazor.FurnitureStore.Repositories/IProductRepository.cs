using Blazor.FurnitureStore.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
        Task<Product> GetProductById(int Id);
    }
}
