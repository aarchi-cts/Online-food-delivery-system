using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interface
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int? OrderID);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int OrderID);
        Task UpdateAgentAsync(Agent agent);
        Task<Agent?> GetAvailableAgentAsync();
        Task UpdateDeliveryAsync(Delivery delivery);

        // Removed duplicate method declaration for UpdateAgentAsync
    }
}
