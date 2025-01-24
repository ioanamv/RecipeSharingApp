using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSharingApp.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(45)]
        public string Username { get; set; }

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; }

        [Required, MaxLength(45)]
        public string Email { get; set; }
    }
}
