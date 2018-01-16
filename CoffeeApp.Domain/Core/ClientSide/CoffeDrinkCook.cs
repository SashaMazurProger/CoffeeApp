using CoffeeApp.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Core.ClientSide
{
    public delegate void DrinkCooked(string message);
    class CoffeDrinkCook : DrinkCook
    {
        public event DrinkCooked drinkReadyEvent;

        public CoffeDrinkCook(IDisplay display, Drink drink)
            : base(display, drink)
        {
        }
        protected override void PreparingIngridients()
        {
            display.ShowInfo("Preparing "+drink.Name+ " ingridients...");
            foreach (var ing in drink.ingridients)
            {
                ing.Cooking();
            }
        }
        protected override void MixingDrink()
        {
            display.ShowInfo("Mixing...");
        }
        protected override void Finally()
        {
            display.ShowInfo("The end:) Please, take your "+drink.Name);
            if (drinkReadyEvent != null)
            { 
              drinkReadyEvent.Invoke("The end:) Please, take your "+drink.Name);
            }
        }
    }
}
