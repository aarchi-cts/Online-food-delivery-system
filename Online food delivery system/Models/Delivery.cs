using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_food_delivery_system.Models
{
    public class Delivery
    {

        [Key]
        public int DeliveryID { get; set; }

       
        public int? OrderID { get; set; }
        public Order?Order { get; set; }

       
      
        public int? AgentID { get; set; }
        public string Status { get; set; }

        public DateTime EstimatedTimeOfArrival { get; set; }

        // [ForeignKey("Payment")]
        //public int OrderId { get; set; }
        //[ForeignKey("OrderID")]
        //public Payment? Payment { get; set; }
        [ForeignKey("AgentID")]
        public Agent? Agent { get; set; }


    }
}
