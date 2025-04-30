using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_food_delivery_system.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }


        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }


        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public Payment? Payment { get; set; }
        public Delivery? Delivery { get; set; }

        //public List<Restaurant> Restaurants { get; set; }
    }
    }
