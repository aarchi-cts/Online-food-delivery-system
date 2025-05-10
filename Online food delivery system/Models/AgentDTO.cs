using System.ComponentModel.DataAnnotations;

namespace Online_food_delivery_system.Models
{
    public class AgentDTO
    {
        public string? Name { get; set; }
        public string? AgentContact { get; set; }

        public string? Email { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
