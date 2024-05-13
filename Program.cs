using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Collection to store recipes
            List<Recipe> recipes = new List<Recipe>();

            // Delegate to notify user when total calories exceed 300
            NotificationDelegate notify;

            // Add the notification method to the delegate
            notify = NotifyUser;

            bool exit = false;

            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("***   Welcome to my family Recipe Secret App   ***");
            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");

            while (!exit)
            {
                Console.WriteLine("Enter your option:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Recipe");
                Console.WriteLine("6. Clear Recipe");
                Console.WriteLine("7. Quit");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        Recipe newRecipe = new Recipe();
                        newRecipe.EnterRecipeDetails();
                        // Add the recipe to the list
                        recipes.Add(newRecipe);
                        break;

                    case "2":
                        DisplayAllRecipes(recipes);
                        break;

                    case "3":
                        DisplayRecipe(recipes);
                        break;

                    case "4":
                        ScaleRecipe(recipes);
                        break;

                    case "5":
                        ResetRecipe(recipes);
                        break;

                    case "6":
                        ClearRecipeData(recipes);
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Incorrect Option!!! Please Try Again");
                        break;
                }
            }
        }

        // Method to display all recipes
        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("All Recipes:");
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.WriteLine("*****************************************");
        }

        // Method to display a specific recipe
        static void DisplayRecipe(List<Recipe> recipes)
        {
            Console.WriteLine("Enter the name of the recipe you want to display:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.Find(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        // Method to scale a recipe
        static void ScaleRecipe(List<Recipe> recipes)
        {
            Console.WriteLine("Enter the name of the recipe you want to scale:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.Find(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.ScaleRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        // Method to reset a recipe
        static void ResetRecipe(List<Recipe> recipes)
        {
            Console.WriteLine("Enter the name of the recipe you want to reset:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.Find(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.ResetRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        // Method to clear recipe data
        static void ClearRecipeData(List<Recipe> recipes)
        {
            Console.WriteLine("Enter the name of the recipe you want to clear:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.Find(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipes.Remove(recipe);
                Console.WriteLine("Recipe cleared!");
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        // Method to notify user
        static void NotifyUser(string message)
        {
            Console.WriteLine(message);
        }

        // Delegate to notify user
        public delegate void NotificationDelegate(string message);




    }
}