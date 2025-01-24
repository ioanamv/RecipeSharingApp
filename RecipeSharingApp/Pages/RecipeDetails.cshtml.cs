using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;

namespace RecipeSharingApp.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        public Recipe? SelectedRecipe { get; set; }
        public IActionResult OnGet(int id)
        {
            //SelectedRecipe=RecipesData.Recipes.FirstOrDefault(x => x.RecipeId == id);
            if (SelectedRecipe == null)
                return NotFound();
            return Page();
        }
    }
}
