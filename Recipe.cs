using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    internal class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }
        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter recipe name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();

                Console.Write($"Enter Ingredient {i + 1} Name:");
                ingredient.Name = Console.ReadLine();

                Console.Write($"Enter Ingredient {i + 1} Quantity:");
                ingredient.Quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter Ingredient {i + 1} Unit of Measurement:");
                ingredient.Unit = Console.ReadLine();

                Console.Write($"Enter Ingredient {i + 1} Calories:");
                ingredient.Calories = double.Parse(Console.ReadLine());

                Console.Write($"Enter Ingredient {i + 1} Food Group:");
                ingredient.FoodGroup = Console.ReadLine();

                Ingredients.Add(ingredient);
            }

            // Calculate total calories
            double totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Check if total calories exceed 300 and notify user
            if (totalCalories > 300)
            {
                NotificationDelegate notify;
                notify = NotifyUser;
                notify("Total calories of the recipe exceed 300!");
            }

            Console.WriteLine("Enter number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}:");
                Steps.Add(Console.ReadLine());
            }
        }


        // Method to display recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine($"Recipe: {Name}");

            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }

            Console.WriteLine("*****************************************");
        }

        // Method to scale recipe
        public void ScaleRecipe()
        {
            Console.Write("Enter scaling factor (0.5, 2 or 3): ");
            double scalingFactor = double.Parse(Console.ReadLine());

            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= scalingFactor;
            }

            Console.WriteLine("*****************************************");
            Console.WriteLine("*****     Recipe has been Scaled    *****");
            Console.WriteLine("*****************************************");
        }

        // Method to reset recipe
        public void ResetRecipe()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity /= 2; // Assuming original quantity was doubled
            }

            Console.WriteLine("*Recipe has been reset*");
        }
    }
}