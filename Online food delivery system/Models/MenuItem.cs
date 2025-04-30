using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_food_delivery_system.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name")]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Description of the Item")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Price ")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant?Restaurant { get; set; }

    }
}
