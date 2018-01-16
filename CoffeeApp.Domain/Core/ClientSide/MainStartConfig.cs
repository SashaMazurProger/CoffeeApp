using CoffeeApp.Domain.Abstract;
using CoffeeApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Core.ClientSide
{
    public class MainStartConfig
    {
        public static void Main()
        {
            Logger.RecordMessageToLog("werfewf");
           IIngsRepository ingsRepo=new IngsRepository();

           IDrinkRepository drinksRepo=new DrinkRepository();

           IDisplay display=new ConsoleDisplay();

           OrderController ordController=new ConsoleOrderController(drinksRepo,ingsRepo,display);

           Automat automat = new Automat(ordController,drinksRepo,display,ingsRepo,"geo:32434:43245");

           AutomatEventService eventService = new AutomatEventService(automat, display);

           automat.StartAutomat();
        }
    }
}
