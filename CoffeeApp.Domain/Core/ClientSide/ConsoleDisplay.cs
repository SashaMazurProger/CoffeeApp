using CoffeeApp.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Core.ClientSide
{
    public class ConsoleDisplay:IDisplay
    {
        public void ShowInfo(string message)
        {
            Console.WriteLine(message);
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
