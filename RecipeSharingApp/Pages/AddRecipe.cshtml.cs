using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;
using System.Security.Claims;

namespace RecipeSharingApp.Pages
{
    [Authorize]
    public class AddRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; }

        public List<string> AvailableCategories { get; set; } = new List<string> { "Breakfast", "Main Dish", "Dessert" };
        public List<string> AvailableRegions { get; set; } = new List<string> { "Romania", "Italy", "UK", "China", "Japan", "Nigeria", "South Africa" };

        private readonly AppDbContext _context;

        public AddRecipeModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Recipe=new Recipe();
        }

        public IActionResult OnPost(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("wwwroot/images", image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                Recipe.ImageUrl = $"/images/{image.FileName}";
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userId == null)
                Forbid();

            Recipe.UserId=int.Parse(userId.Value);
            
            _context.Recipes.Add(Recipe);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}
