using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//create new menu items, delete menu items, and receive a list of all items on the cafe's menu.
namespace Cafe_Console
{
    class Program_UI
    {
        private MenuRepository _menuRepository = new MenuRepository();
        private Menu _menu = new Menu();
        private readonly List<Menu> _ListOfMeals = new List<Menu>();
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Select a numerical menu option:\n" +
                    "1.Add a Meal\n" +
                    "2.View Menu\n" +
                    "3.Remove a Meal\n" +
                    "4.Exit");
                int userInput = int.Parse(Console.ReadLine());
                
                switch (userInput)
                {
                    case 1:
                        CreateNewMeal();
                        break;
                    case 2:
                        DisplayMenu();
                        break;
                    case 3:
                        DeleteExistingMeal();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a valid choice using (1-4)");
                        break;
                }
            }
        }
        //Name, Description, Ingredients, Price
        private void CreateNewMeal() 
        {
            Menu newMeal = new Menu();
            Console.Clear();
            Console.WriteLine("Please Enter the Meal's name:");
            newMeal.Name = Console.ReadLine();
            Console.WriteLine("Please give a description of the meal:");
            newMeal.Description = Console.ReadLine();
            Console.WriteLine("Please list the ingredients in the meal seperated by a comma:");
            newMeal.Ingredients = Console.ReadLine();
            Console.WriteLine("Please enter the meal price:");
            newMeal.Price = Decimal.Parse(Console.ReadLine());
            Console.Clear();
            _menuRepository.AddMealToList(newMeal);
        }
        private void DisplayMenu()
        {
            List<Menu> listOfMeals = _menuRepository.GetMealList();
            Console.Clear();
            foreach(Menu meal in listOfMeals)
            {
                Console.WriteLine($"Meal Number:{meal.ID}\n" +
                    $"Name:{meal.Name}\n" +
                    $"{meal.Description}\n" +
                    $"{meal.Ingredients}\n" +
                    $"{meal.Price}\n");
            }
        }
        private void DeleteExistingMeal()
        {
            DisplayMenu();
            Console.WriteLine("Enter the meal number you would like to remove:");
            int userInput = int.Parse(Console.ReadLine());
            bool wasRemoved = _menuRepository.RemoveMealFromList(userInput);

            if (wasRemoved)
            {
                Console.WriteLine("The meal was removed.\n");
            }
            else
            {
                Console.WriteLine("No meal found by the number.\n");
            }
        }
    }
}
