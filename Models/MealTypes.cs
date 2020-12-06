using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class MealTypes
    {
        public int MealTypeId { get; set; }
        [StringLength(40)]
        public string MealType { get; set; }
    }
}
