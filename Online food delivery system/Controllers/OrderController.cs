using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Service;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly MenuItemService _menuItemService;

        public OrderController(OrderService orderService, MenuItemService menuItemService)
        {
            _orderService = orderService;
            _menuItemService = menuItemService;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderDto)
        {
            if (orderDto == null || orderDto.MenuItemIDs == null || !orderDto.MenuItemIDs.Any())
                return BadRequest("Invalid order data. MenuItemIDs must be provided.");

            var menuItems = new List<MenuItem>();
            decimal totalAmount = 0;

            foreach (var itemId in orderDto.MenuItemIDs)
            {
                var item = await _menuItemService.GetMenuItemByIdAsync(itemId);
                if (item == null)
                    return NotFound($"Menu item with ID {itemId} not found.");

                menuItems.Add(item);
                totalAmount += item.Price ?? 0;
            }

            var order = new Order
            {
                CustomerID = orderDto.CustomerID,
                RestaurantID = orderDto.RestaurantID,
                Status = orderDto.Status,
                TotalAmount = totalAmount,
                OrderMenuItems = menuItems.Select(mi => new OrderMenuItem
                {
                    ItemID = mi.ItemID
                }).ToList()
            };

            var createdOrder = await _orderService.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderID }, createdOrder);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderID) return BadRequest("Order ID mismatch");
            var updatedOrder = await _orderService.UpdateOrderAsync(order);
            return Ok(updatedOrder);
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
