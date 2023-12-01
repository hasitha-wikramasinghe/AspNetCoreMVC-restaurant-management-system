using System.Collections;
using System.ComponentModel.DataAnnotations;
using RestaurantManagement.MasterData.Models;

namespace RestaurantManagement.FoodOrdering.Models
{
    public class FoodOrderDTO
    {
        public int Id { get; set; }
        [Display(Name = "Order Code")]
        public string OrderCodeString
        {
            get
            {
                return $"#ORD_{OrderCode}";
            }
            set
            {

            }
        }
        public int OrderCode { get; set; }
        public decimal TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public int? FoodOrderStatusId { get; set; }
        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }
        [Display(Name = "Customer Phone Number")]
        public int? CustomerPhoneNumber { get; set; }
        [Display(Name = "Customer NIC")]
        public string? CustomerNIC { get; set; } = string.Empty;
        [Display(Name = "Customer Email")]
        public string? CustomerEmail { get; set; } = string.Empty;
        public string? FoodOrderStatusName { get; set; }
        [Display(Name = "Dining Table")]
        public int? DiningTableId { get; set; }
        [Display(Name = "Order Type")]
        public int? FoodOrderTypeId { get; set; }
        [Display(Name = "Date")]
        public DateOnly FoodOrderDate { get; set; }
        [Display(Name = "Time")]
        public TimeOnly FoodOrderTime { get; set; }

        public ICollection<DiningTable>? DiningTables { get; set; }
        public ICollection<FoodOrderType>? FoodOrderTypes { get; set; }
        public ICollection<Product>? Products { get; set; }

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
