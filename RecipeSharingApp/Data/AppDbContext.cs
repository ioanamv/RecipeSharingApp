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
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Username = "user1", PasswordHash = "1111", Email = "user1@mail.com" },
            new User { UserId = 2, Username = "user2", PasswordHash = "2222", Email = "user2@mail.com" },
            new User { UserId = 3, Username = "user3", PasswordHash = "3333", Email = "user3@mail.com" },
            new User { UserId = 4, Username = "user4", PasswordHash = "4444", Email = "user4@mail.com" }
        );

            modelBuilder.Entity<Recipe>().HasData(
            new Recipe { RecipeId = 1, Title = "Pancakes", Category = "Breakfast", Ingredients = "250g flour\n30g sugar\n10g baking powder\n2g salt\n375ml milk\n2 eggs\n50g melted butter", Instructions = "Mix all ingredients in a bowl. Heat a non-stick pan and pour the batter to form pancakes. Cook until bubbles form, flip, and cook until golden.", PreparationTime = 20, Region = "UK", ImageUrl = "/images/pancakes.jpg", UserId = 1 },
            new Recipe { RecipeId = 2, Title = "Tiramisu", Category = "Dessert", Ingredients = "6 egg yolks\n150g sugar\n250g mascarpone cheese\n400ml heavy cream\n500ml espresso, cooled\n200g ladyfingers\nCocoa powder for dusting", Instructions = "Whisk egg yolks with sugar until creamy. Fold in mascarpone cheese and whipped cream. Layer ladyfingers dipped in espresso and mascarpone mixture. Dust with cocoa and refrigerate.", PreparationTime = 30, Region = "Italy", ImageUrl = "/images/tiramisu.jpg", UserId = 2 },
            new Recipe { RecipeId = 3, Title = "Sarmale", Category = "Main Dish", Ingredients = "500g minced pork\n300g minced beef\n200g rice\n2 onions, finely chopped\n50ml oil\n200g smoked bacon\n1 large pickled cabbage\n1 liter tomato juice", Instructions = "Mix meat with rice, onions, and spices. Wrap the mixture in cabbage leaves to form rolls. Place them in a pot, add bacon slices and tomato juice. Simmer for 2-3 hours.", PreparationTime = 180, Region = "Romania", ImageUrl = "/images/sarmale.jpg", UserId = 1 },
            new Recipe { RecipeId = 4, Title = "Sushi", Category = "Main Dish", Ingredients = "400g sushi rice\n600ml water\n80ml rice vinegar\n10g sugar\n2g salt\nNori seaweed sheets\nFresh fish, cucumber, avocado", Instructions = "Cook sushi rice. Mix with vinegar, sugar, and salt. Place rice on nori sheet, add fillings, and roll tightly. Slice into bite-sized pieces.", PreparationTime = 40, Region = "Japan", ImageUrl = "/images/sushi.jpg", UserId = 2 },
            new Recipe { RecipeId = 5, Title = "Chow Mein", Category = "Main Dish", Ingredients = "250g egg noodles\n200g chicken breast, sliced\n1 carrot, julienned\n1 bell pepper, sliced\n50ml soy sauce\n2 tablespoons oyster sauce\n10g ginger, grated\n2 garlic cloves, minced", Instructions = "Stir-fry chicken with ginger and garlic. Add vegetables and sauces, then stir in cooked noodles. Mix thoroughly and serve hot.", PreparationTime = 25, Region = "China", ImageUrl = "/images/chowmein.jpg", UserId = 1 },
            new Recipe { RecipeId = 6, Title = "Jollof Rice", Category = "Main Dish", Ingredients = "500g long-grain rice\n400g canned tomatoes\n150g tomato paste\n1 onion, chopped\n2 bell peppers, sliced\n2 garlic cloves, minced\n100ml vegetable oil\n500ml chicken stock", Instructions = "Cook onions and tomato paste in oil. Add blended tomatoes, bell peppers, and spices. Stir in rice and stock, then simmer until cooked.", PreparationTime = 50, Region = "Nigeria", ImageUrl = "/images/jollofrice.jpg", UserId = 2 },
            new Recipe { RecipeId = 7, Title = "Bobotie", Category = "Main Dish", Ingredients = "500g minced beef, 1 onion, chopped, 2 slices of bread, 150ml milk, 2 eggs, 2 tablespoons curry powder, 50g raisins, Bay leaves", Instructions = "Soak bread in milk. Mix with beef, onions, curry powder, and raisins. Bake in a casserole dish with an egg mixture on top, garnished with bay leaves.", PreparationTime = 60, Region = "South Africa", ImageUrl = "/images/bobotie.jpg", UserId = 1 }
        );

            modelBuilder.Entity<Comment>().HasData(
           new Comment { CommentId = 1, Content = "This recipe is amazing! I made it last weekend, and it was a hit with my family. Highly recommend!", RecipeId = 1, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 2, Content = "Very easy to make and delicious! The instructions were clear, and the flavor was spot on. I'll definitely make it again.", RecipeId = 1, UserId = 4, Time = DateTime.Now },
           new Comment { CommentId = 3, Content = "A fantastic dish! The flavors were so rich and satisfying. My guests loved it!", RecipeId = 2, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 4, Content = "Great dessert! Simple to prepare and the taste was incredible. Will make it again for sure.", RecipeId = 2, UserId = 4, Time = DateTime.Now },
           new Comment { CommentId = 5, Content = "A true comfort food! I followed the recipe exactly and it turned out perfectly. A family favorite!", RecipeId = 3, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 6, Content = "So flavorful and hearty. The dish was a bit time-consuming, but worth every minute. Definitely making it again.", RecipeId = 3, UserId = 4, Time = DateTime.Now },
           new Comment { CommentId = 7, Content = "The sushi was fresh and easy to prepare. I loved how everything came together. Will make it again soon!", RecipeId = 4, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 8, Content = "Delicious! The combination of ingredients was perfect, and it was so satisfying. Highly recommend this recipe!", RecipeId = 4, UserId = 4, Time = DateTime.Now },
           new Comment { CommentId = 9, Content = "Tasty and quick! This recipe was a big hit at dinner time, and it was so simple to make.", RecipeId = 5, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 10, Content = "I added a few extra veggies to the mix and it turned out even better! So flavorful.", RecipeId = 5, UserId = 4, Time = DateTime.Now },
           new Comment { CommentId = 11, Content = "Loved this dish! The flavors were fantastic, and it was just the right amount of spice. I'll definitely cook it again.", RecipeId = 6, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 12, Content = "Amazing! This is one of my favorite recipes. The rice and sauce combination is perfect.", RecipeId = 6, UserId = 4, Time = DateTime.Now },
           new Comment { CommentId = 13, Content = "This was a fantastic dinner! The flavors of the beef and spices really stood out. My family loved it!", RecipeId = 7, UserId = 3, Time = DateTime.Now },
           new Comment { CommentId = 14, Content = "Great recipe! The curry flavor was amazing, and the dish was easy to make. I'll definitely be making this again.", RecipeId = 7, UserId = 4, Time = DateTime.Now }
       );

        }
    }
}
