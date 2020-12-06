using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class Recipes
    {
        public int RecipeId { get; set; }
        [StringLength(40)]
        public string RecipeName { get; set; }
        public int? DirectionId { get; set; }
    }
}
