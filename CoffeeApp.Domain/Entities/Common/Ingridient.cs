using System;

namespace CoffeeApp.Domain.Entities.Common
{
    public class Ingridient
    {

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public double Portion { get; private set; }

        public double CountInMachine { get; private set; }

        public Ingridient( string name, decimal portionPrice, double countInMachine, double portion)
        {
 
            this.Name = name;
            this.Price = portionPrice;
            this.CountInMachine = countInMachine;
            this.Portion = portion;
        }

        public void Withdrawn(double minus)
        {
            CountInMachine -= minus;
        }

        public void Add(double plus)
        {
            CountInMachine += plus;
        }

        public bool HasPortion()
        {
            return CountInMachine >= Portion;
        }
    }
}
