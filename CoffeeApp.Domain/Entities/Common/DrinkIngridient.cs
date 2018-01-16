namespace CoffeeApp.Domain.Entities.Common
{
    public class DrinkIngridient
    {
        public Ingridient CurrentIngridient { get; private set; }

        public int PortionCount { get;private set; }

        public DrinkIngridient(Ingridient ing)
        {
            this.CurrentIngridient = ing;
        }

        public void SetCountPortion(int count)
        {
            this.PortionCount = count;
        }
        public string GetName()
        {
            return CurrentIngridient.Name;
        }
        public decimal GetPrice()
        {
            return CurrentIngridient.Price * PortionCount;
        }

        public bool HasPortion()
        {
            return CurrentIngridient.HasPortion();
        }
        public bool HasPortions(int count)
        {
            return CurrentIngridient.CountInMachine>=(CurrentIngridient.Portion*count);
        }
        public void Cooking()
        {
            CurrentIngridient.Withdrawn(CurrentIngridient.Portion * PortionCount);
        }
    }
}
