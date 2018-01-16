using CoffeeApp.Domain.Abstract;
using CoffeeApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Core.ClientSide
{
    public class ConsoleOrderController : OrderController
    {
        private Drink newDrink;

        DrinkCook cooker;

        public ConsoleOrderController(IDrinkRepository drinks, IIngsRepository ingsRepo, IDisplay display)
            : base(drinks, display, ingsRepo)
        {
  
        }
        
        public override void MainMenu()
        {
            do
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\n---COFFEE BANK---");
                sb.AppendLine("\n1-New drink");
                display.ShowInfo(sb.ToString());

                display.ShowInfo("\nInput...");
                int choose;
                int.TryParse(Console.ReadLine(), out choose);
                if (choose == 1)
                {
                    NewDrink();
                    if (newDrink != null)
                    {
                        AddIngridient();
                        TakeMoney();
                        EndCooking();
                    }
                }

            } while (true);

        }

        public override void NewDrink()
        {
            List<Drink> drinks = drinksRepo.GetAutomatDrinks();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < drinks.Count; ++i)
            {
                sb.AppendLine("\n" + i + " - " + drinks[i].Name+ " price:"+drinks[i].Price+" uah");
            }
            display.ShowInfo(sb.ToString());

            int chooseDr;

            display.ShowInfo("\nNumber drink:");

            int.TryParse(Console.ReadLine(), out chooseDr);

            try
            {
                if (drinks[chooseDr] != null)
                {
                    newDrink = drinks[chooseDr];
                }
            }
            catch (Exception)
            {
                display.ShowInfo("\nWrong input");
            }
        }

        public override void TakeMoney()
        {
            display.ShowInfo("Please, put " + newDrink.GetFullCost() + " uah");
            Console.ReadKey();
        }

        public override void AddIngridient()
        {
            List<Ingridient> ings = ingsRepo.GetIngs();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ings.Count; ++i)
            {
                sb.AppendLine("\n" + i + " - " + ings[i].Name + " price:" + ings[i].Price + " portion:" + ings[i].Portion);
            }

            sb.AppendLine("\n-1 - Next");

            display.ShowInfo(sb.ToString());

            int chooseIng = -1;
            do
            {
                chooseIng = -1;
                try
                {

                    display.ShowInfo("\nAdd ingridient numb:");

                    int.TryParse(Console.ReadLine(), out chooseIng);

                    if (chooseIng == -1)
                    {
                        return;
                    }

                    DrinkIngridient curIng = new DrinkIngridient(ings[chooseIng]);

                    if (curIng != null)
                    {
                        int countIng;
                        do
                        {
                            display.ShowInfo("Count:");
                            int.TryParse(Console.ReadLine(), out countIng);
                            if (!curIng.HasPortions(countIng))
                            {
                                display.ShowInfo("\nNot enough the ingridient");
                                Thread.Sleep(1000);
                                AddIngridient();
                            }
                        } while (countIng<=0);

                        curIng.SetCountPortion(countIng);

                        newDrink.AddIngridient(curIng);

                        display.ShowInfo("Added");
                    }
                }
                catch (Exception)
                {
                    display.ShowInfo("\nWrong input");
                }
            } while (chooseIng != -1);
        }
        public override void EndCooking()
        {
            cooker = new CoffeDrinkCook(this.display, newDrink);
            cooker.Cook();
        }
        private void OnCookFinally(string message)
        {
            display.ShowInfo(message);
        }
    }
}
