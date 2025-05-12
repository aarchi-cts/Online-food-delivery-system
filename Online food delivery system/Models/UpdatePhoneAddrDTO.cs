using System.ComponentModel.DataAnnotations;

namespace Online_food_delivery_system.Models
{
    public class UpdatePhoneAddrDTO
    {
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
    }
}
