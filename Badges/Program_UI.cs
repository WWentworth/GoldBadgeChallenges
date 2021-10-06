using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    class Program_UI
    {
        private Outing _outing = new Outing();
        private Event _event = new Event();
        private readonly List<Event> _ListOfOutings = new List<Event>();
        
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
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
            Console.WriteLine("How much did it cost per person?");
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
                Console.WriteLine($"Outing Number:{outing.ID}\n" +
                    $"Outing Type:{outing.Outing}\n" +
                    $"Date:{outing.Date}\n" +
                    $"Attendence:{outing.Attendence}\n" +
                    $"Cost Per Employee:{outing.PersonCost}\n" +
                    $"Event Cost: {outing.EventCost}\n");
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
            Console.WriteLine($"Total cost of all outings is {totalEventCost}\n");
        }
        //find the cost of outing by type

        private void DisplayCostByType()
        {
            Console.WriteLine("Please enter the outing type (golf, bowling, amusement park, concert)");
           string outingType = Console.ReadLine();
            List<Event> listOfOutings = _outing.GetOutingList();
            decimal totalCostByType = 0;
            Console.Clear();
            totalCostByType = listOfOutings.Where(outing => outing.Outing.Equals(outingType)).Sum(outing => outing.EventCost);
            Console.WriteLine($"Total cost of {outingType} outings is {totalCostByType}\n");

        }
    }
}
