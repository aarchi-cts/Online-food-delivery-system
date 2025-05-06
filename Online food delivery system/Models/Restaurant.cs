using System.ComponentModel.DataAnnotations;

namespace Online_food_delivery_system.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }

        [Required]
        [MaxLength(255)]
        public string? RestaurantName { get; set; }

        [Required(ErrorMessage = "Please Enter your Contact")]
        [MaxLength(15)]
        public string? RestaurantContact { get; set; }

        [Required]
        public bool? Availability { get; set; }

        [Required(ErrorMessage = "Please Enter your Address")]
        public string? Address { get; set; }

        //[Required(ErrorMessage = "Please Enter your Password")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        public List<MenuItem>? MenuItems { get; set; } = new List<MenuItem>();
        public List<Order>? Orders { get; set; } // Add this property to fix the error  
    }
}
