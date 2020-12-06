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
    public class IndexModel : PageModel
    {
        private readonly RecipeApi.Data.RecipeSharingDbContext _context;

        public IndexModel(RecipeApi.Data.RecipeSharingDbContext context)
        {
            _context = context;
        }

        public IList<Recipes> Recipes { get;set; }

        public async Task OnGetAsync()
        {
            Recipes = await _context.Recipes.ToListAsync();
        }
    }
}
