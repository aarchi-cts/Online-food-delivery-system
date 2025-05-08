using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_food_delivery_system.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }


        [Required (ErrorMessage ="Please Enter Your Name")]
        [MaxLength(255)]
        public string? Name { get; set;}

        [Required (ErrorMessage ="Please Enter Your Email")]
        [EmailAddress]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "Please Enter Your Phone")]
        //[Phone]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        public string? Address { get; set; }    
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
