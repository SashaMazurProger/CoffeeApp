using CoffeeApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Abstract
{
    public interface InterfaceIngridientService
    {
        void AddOverIngridient(Ingridient ing, Automat automat);
    }
}
