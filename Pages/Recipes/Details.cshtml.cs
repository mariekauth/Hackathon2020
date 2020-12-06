using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeApi.Data.RecipeSharingDbContext _context;

        public DetailsModel(RecipeApi.Data.RecipeSharingDbContext context)
        {
            _context = context;
        }

        public Recipes Recipes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipes = await _context.Recipes.FirstOrDefaultAsync(m => m.RecipeId == id);

            if (Recipes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
