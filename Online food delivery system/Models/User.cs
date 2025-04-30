using System.ComponentModel.DataAnnotations;

namespace Online_food_delivery_system.Models
{

    public class User
    {
        [Key]
        public int ID{ get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please specify a role")]
        [MaxLength(50)]
        public string Role { get; set; }
    }
}
