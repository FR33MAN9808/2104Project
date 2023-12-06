using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;

namespace RecipeManager.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RecipeManagerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RecipeManagerContext>>()))
        {
            if (context == null || context.Recipe == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            if (context.Recipe.Any())
            {
                return;
            }

            context.Recipe.AddRange(
                new Recipe
                {
                    Title = "Spaghetti Bolognese",
                    Type = "Noodle",
                    Ingredients = "Ground beef, tomatoes, onions, garlic, pasta",
                    Instructions = "1. Brown the ground beef. 2. Add chopped onions and garlic. 3. Stir in tomatoes. 4. Cook pasta separately. 5. Combine and serve."
                },

                new Recipe
                {
                    Title = "Chicken Alfredo",
                    Type = "Chicken",
                    Ingredients = "Chicken breast, fettuccine, cream, parmesan cheese, garlic",
                    Instructions = "1. Cook chicken. 2. Boil fettuccine. 3. Make Alfredo sauce with cream, parmesan, and garlic. 4. Combine and serve."
                },

                new Recipe
                {
                    Title = "Vegetarian Stir-Fry",
                    Type = "Vegie",
                    Ingredients = "Assorted vegetables, tofu, soy sauce, ginger, garlic",
                    Instructions = "1. Stir-fry vegetables. 2. Add tofu. 3. Season with soy sauce, ginger, and garlic. 4. Serve over rice."
                },

                new Recipe
                {
                    Title = "Chocolate Chip Cookies",
                    Type = "Bakery",
                    Ingredients = "Flour, butter, sugar, chocolate chips, baking soda",
                    Instructions = "1. Cream butter and sugar. 2. Mix in flour and baking soda. 3. Add chocolate chips. 4. Bake until golden brown."
                }
            );
            context.SaveChanges();
        }
    }
}