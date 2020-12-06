using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class Tags
    {
        public int TagId { get; set; }
        [StringLength(40)]
        public string Tag { get; set; }
    }
}
