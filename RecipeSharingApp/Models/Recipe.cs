using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSharingApp.Models
{
    [Table("recipes")]
	public class Recipe
	{
        [Key]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Title is required."), MaxLength(45)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required."), MaxLength(45)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Ingredients are required."), MaxLength(1000)]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Instructions are required."), MaxLength(2000)]
        public string Instructions { get; set; }

        [Range(1, 9999, ErrorMessage = "Preparation time must be a positive number.")]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = "Region is required."), MaxLength(45)]
        public string Region { get; set; }

        [Required(ErrorMessage = "Image URL is required."), MaxLength(45)]
        public string ImageUrl { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
	}
}
