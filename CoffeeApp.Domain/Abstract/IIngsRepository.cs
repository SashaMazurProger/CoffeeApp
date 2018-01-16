using CoffeeApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Abstract
{
    public interface IIngsRepository
    {
        List<Ingridient> GetIngs();
    }
}
