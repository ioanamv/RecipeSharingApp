using RecipeSharingApp.Models;

namespace RecipeSharingApp.Data
{
	public static class RecipesData
	{
		public static List<Recipe> Recipes = new List<Recipe> 
		{
			new Recipe
			{
				Id = 1,
				Title = "Pancakes",
				Category = "Breakfast",
				Ingredients = "250g flour\n30g sugar\n10g baking powder\n2g salt\n375ml milk\n2 eggs\n50g melted butter",

                Instructions = "Mix all ingredients in a bowl. Heat a non-stick pan and pour the batter to form pancakes. Cook until bubbles form, flip, and cook until golden.",
				ImageUrl = "/images/pancakes.jpg",
				PreparationTime =20,
				Region = "UK"
			},
			new Recipe
			{
				Id = 2,
				Title = "Tiramisu",
				Category = "Dessert",
				Ingredients = "6 egg yolks\n150g sugar\n250g mascarpone cheese\n400ml heavy cream\n500ml espresso, cooled\n200g ladyfingers\nCocoa powder for dusting",
                Instructions = "Whisk egg yolks with sugar until creamy. Fold in mascarpone cheese and whipped cream. Layer ladyfingers dipped in espresso and mascarpone mixture. Dust with cocoa and refrigerate.",
				ImageUrl = "/images/tiramisu.jpg",
				PreparationTime =30,
				Region = "Italy"
			},
			new Recipe
			{
				Id = 3,
				Title = "Sarmale",
				Category = "Main Dish",
				Ingredients = "500g minced pork\n300g minced beef\n200g rice\n2 onions, finely chopped\n50ml oil\n200g smoked bacon\n1 large pickled cabbage\n1 liter tomato juice",
                Instructions = "Mix meat with rice, onions, and spices. Wrap the mixture in cabbage leaves to form rolls. Place them in a pot, add bacon slices and tomato juice. Simmer for 2-3 hours.",
				ImageUrl = "/images/sarmale.jpg",
				PreparationTime =180,
				Region = "Romania"
			},
			new Recipe
			{
				Id = 4,
				Title = "Sushi",
				Category = "Main Dish",
				Ingredients = "400g sushi rice\n600ml water\n80ml rice vinegar\n10g sugar\n2g salt\nNori seaweed sheets\nFresh fish, cucumber, avocado",

                Instructions = "Cook sushi rice. Mix with vinegar, sugar, and salt. Place rice on nori sheet, add fillings, and roll tightly. Slice into bite-sized pieces.",
				ImageUrl = "/images/sushi.jpg",
				PreparationTime = 40,
				Region = "Japan"
			},
			new Recipe
			{
				Id = 5,
				Title = "Chow Mein",
				Category = "Main Dish",
				Ingredients = "250g egg noodles\n200g chicken breast, sliced\n1 carrot, julienned\n1 bell pepper, sliced\n50ml soy sauce\n2 tablespoons oyster sauce\n10g ginger, grated\n2 garlic cloves, minced",
                Instructions = "Stir-fry chicken with ginger and garlic. Add vegetables and sauces, then stir in cooked noodles. Mix thoroughly and serve hot.",
				ImageUrl = "/images/chowmein.jpg",
				PreparationTime = 25,
				Region = "China"
			},
			new Recipe
			{
				Id = 6,
				Title = "Jollof Rice",
				Category = "Main Dish",
				Ingredients = "500g long-grain rice\n400g canned tomatoes\n150g tomato paste\n1 onion, chopped\n2 bell peppers, sliced\n2 garlic cloves, minced\n100ml vegetable oil\n500ml chicken stock",
                Instructions = "Cook onions and tomato paste in oil. Add blended tomatoes, bell peppers, and spices. Stir in rice and stock, then simmer until cooked.",
				ImageUrl = "/images/jollofrice.jpg",
				PreparationTime = 50,
				Region = "Nigeria"
			},
			new Recipe
			{
				Id = 7,
				Title = "Bobotie",
				Category = "Main Dish",
				Ingredients ="500g minced beef, 1 onion, chopped, 2 slices of bread, 150ml milk, 2 eggs, 2 tablespoons curry powder, 50g raisins, Bay leaves",
				Instructions = "Soak bread in milk. Mix with beef, onions, curry powder, and raisins. Bake in a casserole dish with an egg mixture on top, garnished with bay leaves.",
				ImageUrl = "/images/bobotie.jpg",
				PreparationTime =60,
				Region = "South Africa"
			}
		};

		public static void AddRecipe(Recipe recipe)
		{
			recipe.Id = Recipes.Any() ? Recipes.Max(r => r.Id) + 1 : 1;
			Recipes.Add(recipe);
		}
	}
}
