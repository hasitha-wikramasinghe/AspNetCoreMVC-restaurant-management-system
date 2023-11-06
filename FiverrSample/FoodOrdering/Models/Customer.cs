using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "NIC")]
        public string NIC { get; set; } = string.Empty;
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        public int OrdersCompleted { get; set; }
    }
}
