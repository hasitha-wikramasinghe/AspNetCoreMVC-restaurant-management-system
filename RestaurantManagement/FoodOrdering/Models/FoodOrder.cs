using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.FoodOrdering.Models
{
    public class FoodOrder
    {
        public int Id { get; set; }
        public int OrderCode { get; set; } 
        public decimal TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public int? FoodOrderStatusId { get; set; }
        public int? DiningTableId { get; set; }
        public int? FoodOrderTypeId { get; set; }

        public Customer? Customer { get; set; }
        public FoodOrderStatus? FoodOrderStatusList { get; set; }
        public DiningTable? DiningTable { get; set; }
        public ICollection<FoodOrderLineItem>? OrderProducts { get; set; }
        public FoodOrderType? FoodOrderTypeList { get; set; }


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
