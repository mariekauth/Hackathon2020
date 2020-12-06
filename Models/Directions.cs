using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models
{
    public partial class Directions
    {
        public int RecipeId { get; set; }
        public int RecipeSequenceNmbr { get; set; }
        [StringLength(40)]
        public string Instruction { get; set; }
    }
}
