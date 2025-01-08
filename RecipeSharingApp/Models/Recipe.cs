using System.ComponentModel.DataAnnotations;

namespace RecipeSharingApp.Models
{
	public class Recipe
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Ingredients are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Instructions are required.")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        public string ImageUrl { get; set; }

        [Range(1, 9999, ErrorMessage = "Preparation time must be a positive number.")]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = "Region is required.")]
        public string Region { get; set; }
	}
}
