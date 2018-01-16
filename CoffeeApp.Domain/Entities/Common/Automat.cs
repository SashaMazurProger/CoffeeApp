using CoffeeApp.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Threading;


namespace CoffeeApp.Domain.Entities.Common
{
    public delegate void AutomatLoadingDelegate();
    public class Automat: IAutomat
    {
        public string Address { get; set; }
        public bool IsStarted { get; protected set; }
        public bool IsIngridients { get; protected set; }
        public DateTime DateLastService { get; set; }
        public List<Ingridient> Ingridients { get;protected set; }

        private OrderController orderController;

        protected IDrinkRepository drinksRepo;

        protected IIngsRepository ingsRepo;

        protected IDisplay display;

        public event EventHandler<IngridientsOverEventArgs> IngrOverEvent;

        public e

        public Automat(OrderController orderController,
            IDrinkRepository drinksRepo,IDisplay display,
            IIngsRepository ingsRepo,
            string address)
        {
            this.orderController = orderController;
            this.drinksRepo = drinksRepo;
            this.display = display;
            this.ingsRepo = ingsRepo;
            this.Address = address;
        }

        //беремо всі інгрідієнти з репозиторію та вибираємо ті,
        //яких не достатньо для 1-єї порції, та визиваємо подію 
        public void CheckAllIngridients(Object state=null)
        {
            List<Ingridient> overs = new List<Ingridient>();
            foreach (var ing in ingsRepo.GetIngs())
            {
                if (!ing.HasPortion())
                {
                    overs.Add(ing); 
                }
            }
            OnIngrOverEvent(overs);
        }
        protected void OnIngrOverEvent(List<Ingridient> oversIngridients)
        {
            if (oversIngridients == null||IngrOverEvent==null)
            {
                return;
            }
            IngridientsOverEventArgs args = new IngridientsOverEventArgs(oversIngridients);
            IngrOverEvent.Invoke(this, args);
        }

        public void StartAutomat()
        {
            IsStarted=true;
            display.ShowInfo("\nLoading...");
            Timer timer = new Timer(CheckAllIngridients, null, 0, 20000);
            orderController.MainMenu();
        }
    }
}
