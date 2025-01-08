using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeSharingApp.Data;
using RecipeSharingApp.Models;

namespace RecipeSharingApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Recipe> Recipes { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string? FilterCategory { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string? FilterRegion { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public int? FilterMinTime { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public int? FilterMaxTime { get; set; }

        //public List<string> AvailableCategories { get; set; } = new();
        //public List<string> AvailableRegions { get; set; } = new();


        public List<string> AvailableCategories { get; set; } = new List<string> { "Breakfast", "Main Dish", "Dessert" };
        public List<string> AvailableRegions { get; set; } = new List<string> { "Romania", "Italy", "UK", "China", "Japan", "Nigeria", "South Africa" };

        [BindProperty(SupportsGet = true)]
        public string FilterRegion { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCategory { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterPreparationTimeRange { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Recipes=RecipesData.Recipes;

            if (!string.IsNullOrEmpty(FilterRegion))
            {
                Recipes = Recipes.Where(r => r.Region == FilterRegion).ToList();
            }

            if (!string.IsNullOrEmpty(FilterCategory))
            {
                Recipes = Recipes.Where(r => r.Category == FilterCategory).ToList();
            }

            if (!string.IsNullOrEmpty(FilterPreparationTimeRange))
            {
                Recipes = FilterByPreparationTime(Recipes, FilterPreparationTimeRange);
            }
        }

        private List<Recipe> FilterByPreparationTime(List<Recipe> recipes, string range)
        {
            return range switch
            {
                "0-30" => recipes.Where(r => r.PreparationTime <= 30).ToList(),
                "30-60" => recipes.Where(r => r.PreparationTime > 30 && r.PreparationTime <= 60).ToList(),
                "60-90" => recipes.Where(r => r.PreparationTime > 60 && r.PreparationTime <= 90).ToList(),
                "90+" => recipes.Where(r => r.PreparationTime > 90).ToList(),
                _ => recipes
            };
        }
    }
}
