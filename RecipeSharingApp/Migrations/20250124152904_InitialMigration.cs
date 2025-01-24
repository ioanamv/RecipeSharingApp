using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeSharingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ingredients = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instructions = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_recipes_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_comments_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "user1@mail.com", "1111", "user1" },
                    { 2, "user2@mail.com", "2222", "user2" },
                    { 3, "user3@mail.com", "3333", "user3" },
                    { 4, "user4@mail.com", "4444", "user4" }
                });

            migrationBuilder.InsertData(
                table: "recipes",
                columns: new[] { "RecipeId", "Category", "ImageUrl", "Ingredients", "Instructions", "PreparationTime", "Region", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Breakfast", "/images/pancakes.jpg", "250g flour\n30g sugar\n10g baking powder\n2g salt\n375ml milk\n2 eggs\n50g melted butter", "Mix all ingredients in a bowl. Heat a non-stick pan and pour the batter to form pancakes. Cook until bubbles form, flip, and cook until golden.", 20, "UK", "Pancakes", 1 },
                    { 2, "Dessert", "/images/tiramisu.jpg", "6 egg yolks\n150g sugar\n250g mascarpone cheese\n400ml heavy cream\n500ml espresso, cooled\n200g ladyfingers\nCocoa powder for dusting", "Whisk egg yolks with sugar until creamy. Fold in mascarpone cheese and whipped cream. Layer ladyfingers dipped in espresso and mascarpone mixture. Dust with cocoa and refrigerate.", 30, "Italy", "Tiramisu", 2 },
                    { 3, "Main Dish", "/images/sarmale.jpg", "500g minced pork\n300g minced beef\n200g rice\n2 onions, finely chopped\n50ml oil\n200g smoked bacon\n1 large pickled cabbage\n1 liter tomato juice", "Mix meat with rice, onions, and spices. Wrap the mixture in cabbage leaves to form rolls. Place them in a pot, add bacon slices and tomato juice. Simmer for 2-3 hours.", 180, "Romania", "Sarmale", 1 },
                    { 4, "Main Dish", "/images/sushi.jpg", "400g sushi rice\n600ml water\n80ml rice vinegar\n10g sugar\n2g salt\nNori seaweed sheets\nFresh fish, cucumber, avocado", "Cook sushi rice. Mix with vinegar, sugar, and salt. Place rice on nori sheet, add fillings, and roll tightly. Slice into bite-sized pieces.", 40, "Japan", "Sushi", 2 },
                    { 5, "Main Dish", "/images/chowmein.jpg", "250g egg noodles\n200g chicken breast, sliced\n1 carrot, julienned\n1 bell pepper, sliced\n50ml soy sauce\n2 tablespoons oyster sauce\n10g ginger, grated\n2 garlic cloves, minced", "Stir-fry chicken with ginger and garlic. Add vegetables and sauces, then stir in cooked noodles. Mix thoroughly and serve hot.", 25, "China", "Chow Mein", 1 },
                    { 6, "Main Dish", "/images/jollofrice.jpg", "500g long-grain rice\n400g canned tomatoes\n150g tomato paste\n1 onion, chopped\n2 bell peppers, sliced\n2 garlic cloves, minced\n100ml vegetable oil\n500ml chicken stock", "Cook onions and tomato paste in oil. Add blended tomatoes, bell peppers, and spices. Stir in rice and stock, then simmer until cooked.", 50, "Nigeria", "Jollof Rice", 2 },
                    { 7, "Main Dish", "/images/bobotie.jpg", "500g minced beef, 1 onion, chopped, 2 slices of bread, 150ml milk, 2 eggs, 2 tablespoons curry powder, 50g raisins, Bay leaves", "Soak bread in milk. Mix with beef, onions, curry powder, and raisins. Bake in a casserole dish with an egg mixture on top, garnished with bay leaves.", 60, "South Africa", "Bobotie", 1 }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "CommentId", "Content", "RecipeId", "Time", "UserId" },
                values: new object[,]
                {
                    { 1, "This recipe is amazing! I made it last weekend, and it was a hit with my family. Highly recommend!", 1, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5622), 3 },
                    { 2, "Very easy to make and delicious! The instructions were clear, and the flavor was spot on. I'll definitely make it again.", 1, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5668), 4 },
                    { 3, "A fantastic dish! The flavors were so rich and satisfying. My guests loved it!", 2, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5671), 3 },
                    { 4, "Great dessert! Simple to prepare and the taste was incredible. Will make it again for sure.", 2, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5675), 4 },
                    { 5, "A true comfort food! I followed the recipe exactly and it turned out perfectly. A family favorite!", 3, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5679), 3 },
                    { 6, "So flavorful and hearty. The dish was a bit time-consuming, but worth every minute. Definitely making it again.", 3, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5682), 4 },
                    { 7, "The sushi was fresh and easy to prepare. I loved how everything came together. Will make it again soon!", 4, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5684), 3 },
                    { 8, "Delicious! The combination of ingredients was perfect, and it was so satisfying. Highly recommend this recipe!", 4, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5687), 4 },
                    { 9, "Tasty and quick! This recipe was a big hit at dinner time, and it was so simple to make.", 5, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5690), 3 },
                    { 10, "I added a few extra veggies to the mix and it turned out even better! So flavorful.", 5, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5692), 4 },
                    { 11, "Loved this dish! The flavors were fantastic, and it was just the right amount of spice. I'll definitely cook it again.", 6, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5695), 3 },
                    { 12, "Amazing! This is one of my favorite recipes. The rice and sauce combination is perfect.", 6, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5698), 4 },
                    { 13, "This was a fantastic dinner! The flavors of the beef and spices really stood out. My family loved it!", 7, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5700), 3 },
                    { 14, "Great recipe! The curry flavor was amazing, and the dish was easy to make. I'll definitely be making this again.", 7, new DateTime(2025, 1, 24, 17, 29, 4, 314, DateTimeKind.Local).AddTicks(5703), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_RecipeId",
                table: "comments",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_UserId",
                table: "recipes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
