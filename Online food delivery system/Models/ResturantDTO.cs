using System.ComponentModel.DataAnnotations;

namespace Online_food_delivery_system.Models
{
    public class RestaurantDTO
    {
        [Required]
        [MaxLength(255)]
        public string? RestaurantName { get; set; }

        [Required]
        [MaxLength(15)]
        public string? RestaurantContact { get; set; }

        [Required]
        public bool? Availability { get; set; }

        [Required]
        public string? Address { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }

}
