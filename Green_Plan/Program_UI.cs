using Green_Plan_POCO;
using Green_Plan_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan
{
    class Program_UI
    {
        private CarRepo _carRepo = new CarRepo();
        private CarClassRepo _carClassRepo = new CarClassRepo();
        private CarClass _carClass = new CarClass();
        private readonly List<Car> _ListOfCars = new List<Car>();
        public void Run()
        {
            SeedCarList();
            MainMenu();
        }
        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Select the numeric option from the menu:\n" +
                    "1.Add a New Car\n" +
                    "2.View Cars\n" +
                    "3.Update Car\n" +
                    "4.Remove Car\n" +
                    "5.View Car Classes\n" +
                    "6.Add Car to Car Class\n" +
                    "7.Remove Car from Car Class\n" +
                    "8.Exit");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        CreateNewCar();
                        break;
                    case 2:
                        DisplayCars();
                        break;
                    case 3:
                        UpdateExistingCar();
                        break;
                    case 4:
                        RemoveExistingCar();
                        break;
                    case 5:
                        DisplayCarClasses();
                        break;
                    case 6:
                        AddCarToCarClass();
                        break;
                    case 7:
                        RemoveCarFromCarClass();
                        break;
                    case 8:
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please make a valid choice");
                        Console.ResetColor();
                        break;
                }
            }
        }
        private void CreateNewCar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Car newCar = new Car();
            Console.Clear();
            Console.WriteLine("Please enter the Car's Make:");
            newCar.Make = Console.ReadLine();
            Console.WriteLine("Please enter the Car's Model:");
            newCar.Model = Console.ReadLine();
            Console.WriteLine("Please enter the Car's MSRP such as (35,000:)");
            newCar.MSRP = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Car's Horsepower");
            newCar.Horsepower = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Car's Safety Rating Value (if 5 stars put 5)");
            newCar.SafetyRating = decimal.Parse(Console.ReadLine());
            Console.ResetColor();
            _carRepo.AddCarToList(newCar);
        }
        private void DisplayCars()
        {
            List<Car> listOfCars = _carRepo.GetCarList();
            Console.Clear();
            foreach (Car car in listOfCars)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Car ID:{car.ID}\n" +
                    $"Make:{car.Make}\n" +
                    $"Model:{car.Model}\n" +
                    $"MSRP:{car.MSRP}\n" +
                    $"Horsepower:{car.Horsepower}\n" +
                    $"Safety Rating:{car.SafetyRating}\n");
                Console.ResetColor();
            }
        }
        private void UpdateExistingCar()
        {
            DisplayCars();
            Car newCar = new Car();
            Console.WriteLine("Enter the ID of the Car you would like to update:");
            int oldCar = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please enter the Car's Make:");
            newCar.Make = Console.ReadLine();
            Console.WriteLine("Please enter the Car's Model:");
            newCar.Model = Console.ReadLine();
            Console.WriteLine("Please enter the Car's MSRP such as (35,000:)");
            newCar.MSRP = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Car's Horsepower");
            newCar.Horsepower = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Car's Safety Rating Value (if 5 stars put 5");
            newCar.SafetyRating = decimal.Parse(Console.ReadLine());
            _carRepo.UpdateExistingCar(oldCar, newCar);
        }
        private void RemoveExistingCar()
        {
            DisplayCars();

            Console.WriteLine("Enter the Car's ID you would like to remove:");
            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _carRepo.RemoveCarFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Car was Deleted.\n");
            }
            else
            {
                Console.WriteLine("No Car found with that ID, please input a correct ID.\n");
            }

        }
        private void DisplayCarClasses()
        {
            List<CarClass> listOfCarClasses = _carClassRepo.GetCarClassList();
            Console.Clear();
            foreach (CarClass carClass in listOfCarClasses)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{carClass.Name}\n" +
                    $"Class ID:{carClass.ID}\n" +
                    $"Cars in Class:\n");
                Console.ResetColor();

                foreach (Car car in carClass.CarList)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"ID:{car.ID}\n" +
                        $"Make:{car.Make}\n" +
                        $"Model:{car.Model}\n" +
                        $"MSRP:{car.MSRP}\n" +
                        $"Horsepower:{car.Horsepower}\n" +
                        $"Safety Rating:{car.SafetyRating}\n");
                    Console.ResetColor();
                }
            }
        }
        private void AddCarToCarClass()
        {
            DisplayCarClasses();
            Console.WriteLine("Enter the ID of the Class you are adding a Car to:");
            int userInput = int.Parse(Console.ReadLine());
            DisplayCars();
            Console.WriteLine("Please Enter the ID of the Car being added to Car Class:");
            int carChoice = int.Parse(Console.ReadLine());
            Car carToAdd = _carRepo.GetCarById(carChoice);
            bool carAdded = _carClassRepo.GetCarClassById(userInput).AddCarToCarClass(carToAdd);
        }

        private void RemoveCarFromCarClass()
        {
            DisplayCarClasses();
            Console.WriteLine("Enter the ID of the Class you are removing a Car from:");
            int userInput = int.Parse(Console.ReadLine());
            DisplayCars();
            Console.WriteLine("Please Enter the ID of the Car being removed:");
            int carChoice = int.Parse(Console.ReadLine());
            Car carToRemove = _carRepo.GetCarById(carChoice);
            bool carRemoved = _carClassRepo.GetCarClassById(userInput).AddCarToCarClass(carToRemove);
        }
        private void SeedCarList()
        {
            Car tesla = new Car("Tesla", "Model Y", 39990m, 456, 5);
            CarClass electric = new CarClass("Electric");
            CarClass gas = new CarClass("Gas");
            CarClass hybrid = new CarClass("Hybrid");
            _carRepo.AddCarToList(tesla);
            _carClassRepo.AddCarClassToList(electric);
            _carClassRepo.AddCarClassToList(gas);
            _carClassRepo.AddCarClassToList(hybrid);
        }
    }
}
