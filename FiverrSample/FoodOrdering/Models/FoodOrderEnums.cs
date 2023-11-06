using System.ComponentModel;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public enum FoodOrderStatusEnum
    {
        [Description("Created")]Created = 1,
        [Description("In Progress")]InProgress = 2,
        [Description("Completed")]Completed = 3,
        [Description("Cancelled")]Cancelled = 4
    }

    public enum FoodOrderPaymentStatusEnum
    {
        [Description("Created")] Created = 1,
        [Description("In Progress")] InProgress = 2,
        [Description("Completed")] Completed = 3,
        [Description("Cancelled")] Cancelled = 4
    }
}
