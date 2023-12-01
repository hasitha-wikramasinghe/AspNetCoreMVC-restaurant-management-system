using System.ComponentModel.DataAnnotations;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public class FoodOrderType
    {
        public int Id { get; set; }
        public string? OrderTypeName { get; set; } 
        public string? OrderTypeDescription { get; set; } 
        public ICollection<FoodOrder>? FoodOrders { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
