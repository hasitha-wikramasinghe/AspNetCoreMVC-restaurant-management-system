using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Customer Email")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Customer NIC")]
        public string NIC { get; set; } = string.Empty;
        [Display(Name = "Customer Phone Number")]
        public int PhoneNumber { get; set; }
        public int OrdersCompleted { get; set; }
    }
}
