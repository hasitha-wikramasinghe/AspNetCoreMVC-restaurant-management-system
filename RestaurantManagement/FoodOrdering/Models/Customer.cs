using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.FoodOrdering.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public string? Name { get; set; } = string.Empty;
        [Display(Name = "Customer Email")]
        public string? Email { get; set; } = string.Empty;
        [Display(Name = "Customer NIC")]
        public string? NIC { get; set; } = string.Empty;
        [Display(Name = "Customer Phone Number")]
        public int? PhoneNumber { get; set; }
        public int? OrdersCompleted { get; set; }

        public ICollection<FoodOrder>? FoodOrders { get; set; }


        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Modifed By")]
        public string? ModifiedBy { get; set; } = string.Empty;
        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}
