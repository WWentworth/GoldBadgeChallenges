using Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    class Program_UI
    {
        private Outing _outing = new Outing();
        private Event _event = new Event();
        private readonly List<Event> _ListOfOutings = new List<Event>();
        
        public void Run()
        {
            SeedOutingList();
            MainMenu();
        }

        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Select a numeric response:\n" +
                    "1.List All Outings\n" +
                    "2.Add An Outing\n" +
                    "3.Display All Outings Cost\n" +
                    "4.Display Cost of Outings By Event Type\n" +
                    "5.Exit\n");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        DisplayOutings();
                        break;
                    case 2:
                        CreateNewOuting();
                        break;
                    case 3:
                        DisplayAllOutingCost();
                        break;
                    case 4:
                        DisplayCostByType();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a vaid choice using (1-5)");
                        break;
                }
            }
        }
        private void CreateNewOuting()
        {
            Event newOuting = new Event();
            Console.Clear();
            Console.WriteLine("Please enter the Outing Type (golf, bowling, amusement park, or concert)");
            newOuting.Outing = Console.ReadLine();
            Console.WriteLine("How many employees attended the event?(ex. 25)");
            newOuting.Attendence = int.Parse(Console.ReadLine());
            Console.WriteLine("How much did it cost per person?(ex 5.59)");
            newOuting.PersonCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of the event(Month/Day/Year ex 05/25/2020)");
            newOuting.Date = DateTime.Parse(Console.ReadLine());
            _outing.AddOutingToList(newOuting);
        }
        private void DisplayOutings()
        {
            List<Event> listOfOutings = _outing.GetOutingList();

            Console.Clear();
            foreach(Event outing in listOfOutings)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Outing Number:{outing.ID}\n" +
                    $"Outing Type:{outing.Outing}\n" +
                    $"Date:{outing.Date}\n" +
                    $"Attendence:{outing.Attendence}\n" +
                    $"Cost Per Employee:{outing.PersonCost}\n" +
                    $"Event Cost: {outing.EventCost}\n");
                Console.ResetColor();
            }
        }
        //find the cost of all outings - multiple attendence by PersonCost, sum numbers
        private void DisplayAllOutingCost()
        {
            List<Event> listOfOutings = _outing.GetOutingList();
            decimal totalEventCost = 0;
            Console.Clear();
            foreach(Event outing in listOfOutings)
            {
                totalEventCost += outing.EventCost;

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Total cost of all outings is {totalEventCost}\n");
            Console.ResetColor();
        }
        //find the cost of outing by type

        private void DisplayCostByType()
        {
            Console.WriteLine("Please enter the outing type (golf, bowling, amusement park, concert)");
           string outingType = Console.ReadLine();
            List<Event> listOfOutings = _outing.GetOutingList();
            decimal totalCostByType = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            totalCostByType = listOfOutings.Where(outing => outing.Outing.Equals(outingType)).Sum(outing => outing.EventCost);
            Console.WriteLine($"Total cost of {outingType} outings is {totalCostByType}\n");
            Console.ResetColor();
        }
        private void SeedOutingList()
        {
            Event vent = new Event("golf", 20, 5m, DateTime.Now);
            Event vent2 = new Event("bowling", 33, 5.50m, DateTime.Now);
            _outing.AddOutingToList(vent);
            _outing.AddOutingToList(vent2);
        }
    }
}
