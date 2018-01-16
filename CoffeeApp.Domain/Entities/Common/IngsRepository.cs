using CoffeeApp.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Entities.Common
{
    public class IngsRepository:IIngsRepository
    {
        private static List<Ingridient> ings;
        public List<Ingridient> GetIngs()
        {
            if (ings == null)
            {
                ings = new List<Ingridient>();
                ings.Add(new Ingridient("Milk", 2, 0.5, 1));
                ings.Add(new Ingridient("Sugar", 1, 10,0.5));
                ings.Add(new Ingridient("Koryca", 1, 5, 1));
            }
            return ings;
        }
    }
}
