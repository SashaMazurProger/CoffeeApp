using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Abstract
{
    public abstract class DrinkCook
    {
        
        protected IDisplay display;
        protected Drink drink;
        public DrinkCook(IDisplay display, Drink drink)
        {
            this.display = display;
            this.drink = drink;
        }
        public void Cook()
        {
            PreparingIngridients();
            MixingDrink();
            Finally();
        }
        protected abstract void PreparingIngridients();
        protected abstract void MixingDrink();
        protected abstract void Finally();

        public virtual Drink GetDrink()
        {
            return drink;
        }
    }
}
