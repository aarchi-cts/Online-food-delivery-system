using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interface
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);
    }
}
