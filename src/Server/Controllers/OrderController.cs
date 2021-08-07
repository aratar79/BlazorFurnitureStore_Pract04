using Blazor.FurnitureStore.Repositories;
using Blazor.FurnitureStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Blazor.FurnitureStore.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProructRepository;

        public OrderController
            (
                IOrderRepository orderRepository,
                IOrderProductRepository orderProductRepository
            )
        {
            _orderRepository = orderRepository;
            _orderProructRepository = orderProductRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();
            if (order.OrderNumber == 0)
                ModelState.AddModelError("OrderNumber", "OrderNumber can't be empty");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) 
            {
                order.Id = await _orderRepository.GetNextId();
                await _orderRepository.InsertOrder(order);
                foreach (var product in order.Products)
                {
                    await _orderProructRepository.InsertOrderProduct(order.Id, product);
                }
                scope.Complete();
            }
                            
            return NoContent();
        }

        [HttpGet("GetNextNumber")]
        public async Task<int> GetNextNumber() => await _orderRepository.GetNextNumber();
    }
}
