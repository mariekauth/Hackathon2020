using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class FoodItems
    {
        public int FoodItemsId { get; set; }
        [StringLength(40)]
        public string FoodItem { get; set; }
    }
}
