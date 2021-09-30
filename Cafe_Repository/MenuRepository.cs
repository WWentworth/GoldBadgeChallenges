using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// create new menu items, delete menu items, and receive a list of all items on the cafe's menu
namespace Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfMeals = new List<Menu>();
        public List<Menu> ListOfMeals { get; set; }
        public int _count = 0;
        //create
        public bool AddMealToList(Menu mealToBeAdded)
        {
            if(mealToBeAdded is null)
            {
                return false;
            }
            _count++;
            mealToBeAdded.ID = _count;
            _listOfMeals.Add(mealToBeAdded);
            return true;
        }
        //read
        public List<Menu> GetMealList()
        {
            return _listOfMeals;
        }
        //delete
        public bool RemoveMealFromList(int id)
        {
            var mealToBeDeleted = GetMealByID(id);
            if (mealToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listOfMeals.Remove(mealToBeDeleted);
                return true;
            }
        }
        //find by ID(menu number)
        public Menu GetMealByID(int id)
        {
            foreach(Menu meal in _listOfMeals)
            {
                if(meal.ID == id)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
