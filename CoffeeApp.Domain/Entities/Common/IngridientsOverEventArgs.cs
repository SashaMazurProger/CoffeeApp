using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Entities.Common
{
    public class IngridientsOverEventArgs:EventArgs
    {
        public IngridientsOverEventArgs(List<Ingridient> overIngs)
        {
            this.Ingridients = overIngs;
        }
        public List<Ingridient> Ingridients { get;protected set; }
    }
}
