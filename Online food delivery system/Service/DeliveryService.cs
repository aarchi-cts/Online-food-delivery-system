using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Service
{
    public class DeliveryService
    {
        private readonly IDelivery _deliveryRepository;

        public DeliveryService(IDelivery deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveriesAsync()
        {
            return await _deliveryRepository.GetAllAsync();
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            return await _deliveryRepository.GetByIdAsync(deliveryId);
        }

        public async Task AssignDeliveryAgentAsync(int orderId, int agentId, DateTime estimatedTimeOfArrival)
        {
            var delivery = new Delivery
            {
                OrderID = orderId,
                AgentID = agentId,
                Status = "In Progress",
                EstimatedTimeOfArrival = estimatedTimeOfArrival
            };

            await _deliveryRepository.AddAsync(delivery);
        }

        public async Task UpdateDeliveryStatusAsync(int deliveryId, string status)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(deliveryId);
            if (delivery != null)
            {
                delivery.Status = status;
                await _deliveryRepository.UpdateAsync(delivery);
            }
        }

        public async Task DeleteDeliveryAsync(int deliveryId)
        {
            await _deliveryRepository.DeleteAsync(deliveryId);
        }
    }
}
