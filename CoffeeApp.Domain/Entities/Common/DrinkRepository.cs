using CoffeeApp.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Entities.Common
{
    public class DrinkRepository:IDrinkRepository
    {
        private static List<Drink> drinks;
        public List<Drink> GetAutomatDrinks()
        {
            if (drinks == null)
            {
                drinks = new List<Drink>();
                drinks.Add(new Drink("Latte", 12.5M));
                drinks.Add(new Drink("Espresso", 11M));
                drinks.Add(new Drink("Americano", 10M));
                drinks.Add(new Drink("Capucino", 13M));
            }
            return drinks;
        }
    }
}
