using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeSharingDbContext _context;

        public RecipesController(RecipeSharingDbContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<Recipes> GetRecipes()
        {
            return _context.Recipes;
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipes = await _context.Recipes.FindAsync(id);

            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipes([FromRoute] int id, [FromBody] Recipes recipes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipes.RecipeId)
            {
                return BadRequest();
            }

            _context.Entry(recipes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipes
        [HttpPost]
        public async Task<IActionResult> PostRecipes([FromBody] Recipes recipes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Recipes.Add(recipes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecipesExists(recipes.RecipeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecipes", new { id = recipes.RecipeId }, recipes);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipes = await _context.Recipes.FindAsync(id);
            if (recipes == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipes);
            await _context.SaveChangesAsync();

            return Ok(recipes);
        }

        private bool RecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}