using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi
{
    public class EditModel : PageModel
    {
        private readonly RecipeApi.Data.RecipeSharingDbContext _context;

        public EditModel(RecipeApi.Data.RecipeSharingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recipes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(Recipes.RecipeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}
