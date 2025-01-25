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
    }
}
