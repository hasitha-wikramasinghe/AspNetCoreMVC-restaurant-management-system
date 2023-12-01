using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fiverr_Sample.MasterData.Models;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public class FoodOrderLineItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubPrice
        {
            get
            {
                return Product is not null ? Product.Price * Quantity : decimal.Zero;
            }
        }
        public int StatusId { get; set; }

        public FoodOrder? Order { get; set; }
        public Product? Product { get; set; }
        

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
