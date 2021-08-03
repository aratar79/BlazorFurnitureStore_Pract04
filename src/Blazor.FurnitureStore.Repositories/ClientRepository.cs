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
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dBConnection;
        public ClientRepository(IDbConnection dBConnection)
        {
            _dBConnection = dBConnection;
        }
        public async Task<IEnumerable<ClientStore>> GetAll()
        {
            var Sql = "SELECT * FROM Clients";
            var result =  await _dBConnection.QueryAsync<ClientStore>(Sql, new { });
            return result;
        }
    }
}
