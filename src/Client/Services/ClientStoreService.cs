using Blazor.FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Client.Services
{
    public class ClientStoreService : IClientStoreService
    {
        private readonly HttpClient _httpClient;
        public ClientStoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ClientStore>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ClientStore>>($"api/Clients");
            return result;
        }
    }
}
