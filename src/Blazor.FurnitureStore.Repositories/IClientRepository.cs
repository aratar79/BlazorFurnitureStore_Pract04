using Blazor.FurnitureStore.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientStore>> GetAll();
    }
}
