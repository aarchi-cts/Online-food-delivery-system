using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_food_delivery_system.Models
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }

        [Required(ErrorMessage = "Please Enter Your AgentContact")]
        [MaxLength(15)]
        public string? AgentContact { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [MaxLength(255)]
        public string? Name { get; set; }
        public List<Delivery>? Deliveries { get; set; } = new List<Delivery>(); // An agent can handle multiple deliveries,
                                                                               // so the Delivery property should be a collection.
                                                                               // Initializing it ensures that it is not null when accessed.

    }
}
