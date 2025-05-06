using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interface
{

    public interface IRestaurant
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant> GetByIdAsync(int restaurantId);
        Task AddAsync(Restaurant restaurant);
        Task UpdateAsync(Restaurant restaurant);
        Task DeleteAsync(int restaurantId);
    }
}
