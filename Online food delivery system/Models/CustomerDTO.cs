using System.ComponentModel.DataAnnotations;

namespace Online_food_delivery_system.Models
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        public string? Address { get; set; }

    }
}
