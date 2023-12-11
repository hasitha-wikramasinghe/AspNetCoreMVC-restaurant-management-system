namespace RestaurantManagement.FoodOrdering.Models
{
    public class FoodOrderLineItemDTO
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
