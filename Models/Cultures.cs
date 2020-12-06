using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class Cultures
    {
        public int CultureId { get; set; }
        [StringLength(40)]
        public string Culture { get; set; }
    }
}
