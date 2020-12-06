using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class Ingredients
    {
        public int RecipeId { get; set; }
        public int SeqNo { get; set; }
        [StringLength(40)]
        public string Units { get; set; }
        [StringLength(40)]
        public string Measure { get; set; }
        public int? FoodItemsId { get; set; }
    }
}
