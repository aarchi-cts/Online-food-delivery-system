using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_food_delivery_system.Models
{
    public class Delivery
    {

        [Key]
        public int DeliveryID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order?Order { get; set; }

        [Required]
        [ForeignKey("Agent")]
        public int AgentID { get; set; }
        public Agent?Agent { get; set; }

        public DateTime EstimatedTimeOfArrival { get; set; }

        //[ForeignKey("Payment")]
        //public int OrderId { get; set; }
        public Payment?Payment { get; set; }


    }
}
