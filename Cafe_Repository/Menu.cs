using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* The Menu Items:
A meal number, so customers can say "I'll have the #5" --id from list
A meal name - string
A description - string
A list of ingredients, - string
A price */
namespace Cafe_Repository
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu() { }

        public Menu(string name, string description, string ingredients, decimal price)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
