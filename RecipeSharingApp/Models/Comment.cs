using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharingApp.Models
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required, MaxLength(300)]
        public string Content { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime Time { get; set; }
    }
}
