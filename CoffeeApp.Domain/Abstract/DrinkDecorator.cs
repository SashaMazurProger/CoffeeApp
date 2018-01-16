using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Abstract
{
    public abstract class DrinkDecorator:Drink
    {
        protected Drink drink;
        public DrinkDecorator(string name, Drink drink, decimal price)
            : base(name, price)
        {
            this.drink = drink;
        }
    }
}
