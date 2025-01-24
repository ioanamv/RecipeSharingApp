using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;

namespace RecipeSharingApp.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        public Recipe? SelectedRecipe { get; set; }
        public List<Comment> Comments { get; set; }

        private readonly AppDbContext _context;

        public RecipeDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync(int id)
        {
            SelectedRecipe=_context.Recipes.FirstOrDefault(x => x.RecipeId == id);
            if (SelectedRecipe == null)
                return NotFound();

            Comments=_context.Comments.Where(c=>c.RecipeId == id).Include(c=>c.User).ToList();
            return Page();
        }
    }
}
