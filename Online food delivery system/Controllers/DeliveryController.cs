using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Service;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryService _deliveryService;

        public DeliveryController(DeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var deliveries = await _deliveryService.GetAllDeliveriesAsync();
            return Ok(deliveries);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignDeliveryAgent(int orderId, int agentId, DateTime estimatedTimeOfArrival)
        {
            await _deliveryService.AssignDeliveryAgentAsync(orderId, agentId, estimatedTimeOfArrival);
            return Ok("Delivery agent assigned successfully");
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateDeliveryStatus(int id, [FromBody] string status)
        {
            await _deliveryService.UpdateDeliveryStatusAsync(id, status);
            return Ok("Delivery status updated successfully");
        }
    }
}
