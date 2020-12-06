using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi
{
    public class CreateModel : PageModel
    {
        private readonly RecipeApi.Data.RecipeSharingDbContext _context;

        public CreateModel(RecipeApi.Data.RecipeSharingDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipes Recipes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes.Add(Recipes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}