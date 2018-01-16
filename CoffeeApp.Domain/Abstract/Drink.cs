using CoffeeApp.Domain.Entities.Common;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeApp.Domain.Abstract
{
    public class Drink
    {        
        public string Name { get;protected set; }

        public decimal Price { get;private set; }

        public List<DrinkIngridient> ingridients { get; protected set; }

        public decimal GetFullCost()
        {
            decimal fullPrice = 0;
            foreach (var item in ingridients)
            {
                fullPrice += item.GetPrice();
            }
            fullPrice += this.Price;

            return fullPrice;
        }

        public Drink(string name,decimal price)
        {
            this.Price = price;
            this.Name = name;
            ingridients = new List<DrinkIngridient>();
        }

        public virtual void AddIngridient(DrinkIngridient add)
        {
            ingridients.Add(add);
        }

        public virtual bool CheckIngridients()
        {
            return ingridients.All(x => x.HasPortion());
        }
        public virtual List<Ingridient> GetOverIngridients()
        {
            List<Ingridient> overs = new List<Ingridient>();
            foreach (DrinkIngridient item in ingridients)
            {
                Ingridient ing = item.CurrentIngridient;
                if (!ing.HasPortion())
                {
                    overs.Add(ing);
                }
            }
            return overs;
        }
    }
}
