using CoffeeApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Abstract
{
    public abstract class OrderController
    {
        protected IDisplay display;

        protected IDrinkRepository drinksRepo;

        protected IIngsRepository ingsRepo;
        public OrderController(IDrinkRepository repo,IDisplay display,IIngsRepository ingsRepo)
        {
            this.drinksRepo = repo;
            this.display = display;
            this.ingsRepo = ingsRepo;
        }
        public abstract void MainMenu();
        public abstract void NewDrink();
        public abstract void TakeMoney();
        public abstract void AddIngridient();
        public abstract void EndCooking();
    }
}
