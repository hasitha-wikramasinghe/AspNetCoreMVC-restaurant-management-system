using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public ICollection<FoodOrderLineItem>? OrderProducts { get; set; }


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
