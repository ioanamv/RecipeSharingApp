using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;
using System.Security.Claims;

namespace RecipeSharingApp.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        public Recipe SelectedRecipe { get; set; }
        public List<Comment> Comments { get; set; }

        public string AuthorUsername { get; set; }

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

            var author = _context.Users.FirstOrDefault(u => u.UserId == SelectedRecipe.UserId);
            if(author != null) AuthorUsername = author.Username;
            Comments =_context.Comments.Where(c=>c.RecipeId == id).Include(c=>c.User).ToList();
            return Page();
        }

        public IActionResult OnPostAsync(string content, int recipeId)
        {
            if (string.IsNullOrEmpty(content))
            {
                ModelState.AddModelError(string.Empty, "Comment cannot be empty.");
                return Page();
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userId == null)
                Forbid();

            var newComment = new Comment
            {
                Content = content,
                RecipeId = recipeId,
                UserId = int.Parse(userId.Value),
                Time = DateTime.Now
            };

            _context.Comments.Add(newComment);
            _context.SaveChanges();

            Comments=_context.Comments
                .Where(c=>c.RecipeId==recipeId)
                .Include(c=>c.User)
                .ToList(); 

            return RedirectToPage(new {id=recipeId});
        }
    }
}
