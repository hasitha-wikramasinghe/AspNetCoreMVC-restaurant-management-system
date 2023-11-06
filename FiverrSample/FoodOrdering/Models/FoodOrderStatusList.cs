using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiverr_Sample.FoodOrdering.Models
{
    public class FoodOrderStatusList
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
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
