using Blazor.FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Client.Services
{
    public interface IClientStoreService
    {
        Task<IEnumerable<ClientStore>> GetAll();
    }
}
