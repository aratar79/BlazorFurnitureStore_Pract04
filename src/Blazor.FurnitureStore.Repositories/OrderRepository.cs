using Blazor.FurnitureStore.Shared;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;

namespace Blazor.FurnitureStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task DeleteOrder(int id)
        {
            var sql = @" DELETE FROM Orders WHERE Id = @Id ";

            await _dbConnection.ExecuteAsync(sql,
                            new { Id = id });
        }

        public async Task<int> GetNextNumber()
        {
            var Sql = @"SELECT MAX(OrderNumber) + 1 FROM Orders";
            var result = await _dbConnection.QueryFirstAsync<int?>(Sql, new { });
            if (result == null ) result = 1;
            return (int)result;

        }

        public async Task<int> GetNextId()
        {
            var Sql = @"SELECT IDENT_CURRENT('Orders') + 1";
            return await _dbConnection.QueryFirstAsync<int>(Sql, new { });

        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var sql = @" SELECT o.Id
	                           ,OrderNumber
	                           ,ClientId
	                           ,OrderDate
	                           ,DeliveryDate
	                           ,Total
	                           ,c.LastName + ', ' + c.FirstName As ClientFullName
                        FROM Orders o
	                        INNER JOIN Clients c ON o.ClientId = c.Id ";

            return await _dbConnection.QueryAsync<Order>(sql, new { });
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var sql = @" SELECT Id
	                           ,OrderNumber
	                           ,ClientId
	                           ,OrderDate
	                           ,DeliveryDate
	                           ,Total	                          
                        FROM Orders 
	                    WHERE Id = @Id ";

            return await _dbConnection.QueryFirstOrDefaultAsync<Order>(sql,
                new { Id = orderId });
        }

        public async Task<bool> InsertOrder(Order order)
        {
            var sql = @"
                        INSERT INTO Orders (OrderNumber, ClientId, OrderDate, DeliveryDate, Total)
                        VALUES (@OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @Total)
                        ";

            var result = await _dbConnection.ExecuteAsync(sql,
                new
                {
                    order.OrderNumber,
                    order.ClientId,
                    order.OrderDate,
                    order.DeliveryDate,
                    order.Total
                });

            return result > 0;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            var sql = @"
                        UPDATE Orders 
                            SET ClientId = @ClientId, 
                                OrderDate =  @OrderDate, 
                                DeliveryDate = @DeliveryDate
                        WHERE Id = @Id
                        ";

            var result = await _dbConnection.ExecuteAsync(sql,
                new
                {
                    order.OrderNumber,
                    order.ClientId,
                    order.OrderDate,
                    order.DeliveryDate,
                    order.Total,
                    order.Id
                });

            return result > 0;
        }

    }
}
