using System.ComponentModel;

namespace RestaurantManagement.FoodOrdering.Models
{
    public enum FoodOrderStatusEnum
    {
        [Description("KOT Pending")] KOTPending = 1,
        [Description("KOT Ready")] KOTReady = 2,
        [Description("Served")]Served = 3,
        [Description("Completed")]Completed = 4,
        [Description("Cancelled")] Cancelled = 4
    }

    public enum FoodOrderPaymentStatusEnum
    {
        [Description("Created")] Created = 1,
        [Description("In Progress")] InProgress = 2,
        [Description("Completed")] Completed = 3,
        [Description("Cancelled")] Cancelled = 4
    }

    public enum FoodOrderTypeEnum
    {
        [Description("Dine In")] DineIn = 1,
        [Description("Take Away")] TakeAway = 2,
        [Description("Online Order")] OnlineOrder = 3
    }
}
