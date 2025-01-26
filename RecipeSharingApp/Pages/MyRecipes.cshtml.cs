using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;
using System.Security.Claims;

namespace RecipeSharingApp.Pages
{
    [Authorize]
    public class MyRecipesModel : PageModel
    {
        [BindProperty]
        public int RecipeIdSelected { get; set; }

        public List<Recipe> Recipes { get; set; }

        private readonly AppDbContext _context;

        public MyRecipesModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                Forbid();
                return;
            }

            Recipes = await _context.Recipes
                .Where(r=>r.UserId == int.Parse(userId.Value))
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.RecipeId == RecipeIdSelected);
            if (recipe == null)
                return NotFound();

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
