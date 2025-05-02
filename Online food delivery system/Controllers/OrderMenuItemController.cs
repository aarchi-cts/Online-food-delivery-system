using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Service;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMenuItemController : ControllerBase
    {
    
            private readonly OrderService _orderService;
            private readonly MenuItemService _menuItemService;

            public OrderMenuItemController(OrderService orderService, MenuItemService menuItemService)
            {
                _orderService = orderService;
                _menuItemService = menuItemService;
            }

            // Get: api/OrderMenuItem
            [HttpGet]
            public async Task<IActionResult> GetAllOrderMenuItems()
            {
                var orders = await _orderService.GetAllOrdersAsync();
                var orderMenuItems = orders.SelectMany(o => o.OrderMenuItems);
                return Ok(orderMenuItems);
            }

            // Get: api/OrderMenuItem/{orderId}/{itemId}
            [HttpGet("{orderId}/{itemId}")]
            public async Task<IActionResult> GetOrderMenuItem(int orderId, int itemId)
            {
                var order = await _orderService.GetOrderByIdAsync(orderId);
                if (order == null) return NotFound("Order not found");

                var orderMenuItem = order.OrderMenuItems.FirstOrDefault(omi => omi.ItemID == itemId);
                if (orderMenuItem == null) return NotFound("Menu item not found in order");

                return Ok(orderMenuItem);
            }

            // Post: api/OrderMenuItem
            [HttpPost]
            public async Task<IActionResult> AddOrderMenuItem([FromBody] OrderMenuItem orderMenuItem)
            {
                var order = await _orderService.GetOrderByIdAsync(orderMenuItem.OrderID);
                if (order == null) return NotFound("Order not found");

                var menuItem = await _menuItemService.GetMenuItemByIdAsync(orderMenuItem.ItemID);
                if (menuItem == null) return NotFound("Menu item not found");

                order.OrderMenuItems.Add(orderMenuItem);
                await _orderService.UpdateOrderAsync(order);

                return CreatedAtAction(nameof(GetOrderMenuItem), new { orderId = orderMenuItem.OrderID, itemId = orderMenuItem.ItemID }, orderMenuItem);
            }

            // Delete: api/OrderMenuItem/{orderId}/{itemId}
            [HttpDelete("{orderId}/{itemId}")]
            public async Task<IActionResult> DeleteOrderMenuItem(int orderId, int itemId)
            {
                var order = await _orderService.GetOrderByIdAsync(orderId);
                if (order == null) return NotFound("Order not found");

                var orderMenuItem = order.OrderMenuItems.FirstOrDefault(omi => omi.ItemID == itemId);
                if (orderMenuItem == null) return NotFound("Menu item not found in order");

                order.OrderMenuItems.Remove(orderMenuItem);
                await _orderService.UpdateOrderAsync(order);

                return NoContent();
            }
        }
    }



