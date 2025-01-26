using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;
using System.Security.Claims;

namespace RecipeSharingApp.Pages
{
    public class EditRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; }

        public List<string> AvailableCategories { get; set; } = new List<string> { "Breakfast", "Main Dish", "Dessert" };
        public List<string> AvailableRegions { get; set; } = new List<string> { "Romania", "Italy", "UK", "China", "Japan", "Nigeria", "South Africa" };

        private readonly AppDbContext _context;

        public EditRecipeModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Recipe = _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile image)
        {
            var currentRecipe=_context.Recipes.FirstOrDefault(r=>r.RecipeId==Recipe.RecipeId);
            if (currentRecipe == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(Recipe.Title))
                currentRecipe.Title=Recipe.Title;
            if (!string.IsNullOrEmpty(Recipe.Category))
                currentRecipe.Category=Recipe.Category;
            if (!string.IsNullOrEmpty(Recipe.Ingredients))
                currentRecipe.Ingredients=Recipe.Ingredients;
            if (!string.IsNullOrEmpty(Recipe.Instructions))
                currentRecipe.Instructions=Recipe.Instructions;
            if (Recipe.PreparationTime>0)
                currentRecipe.PreparationTime=Recipe.PreparationTime;
            if (!string.IsNullOrEmpty(Recipe.Region))
                currentRecipe.Region=Recipe.Region;

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("wwwroot/images", image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                currentRecipe.ImageUrl = $"/images/{image.FileName}";
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/MyRecipes");
        }
    }
}
