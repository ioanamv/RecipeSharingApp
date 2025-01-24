using Microsoft.EntityFrameworkCore;
using RecipeSharingApp.Models;

namespace RecipeSharingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // users 1 -> recipes n
            modelBuilder.Entity<Recipe>()
                .HasOne(r=>r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r=>r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // users 1 -> comments n
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // recipe 1 -> comments n
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
