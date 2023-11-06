﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
                return Product.Price * Quantity;
            }
        }
        public int StatusId { get; set; }

        public FoodOrder? Order { get; set; }
        public Product? Product { get; set; }
        public FoodOrderStatusList? FoodOrderStatusList { get; set; }

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
