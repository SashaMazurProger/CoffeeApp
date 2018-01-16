using CoffeeApp.Domain.Abstract;
using CoffeeApp.Domain.Core.ClientSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Entities.Common
{
    public class AutomatEventService
    {
        protected Automat automat;
        protected IDisplay display;
        public AutomatEventService(Automat automat, IDisplay display)
        {
            this.automat = automat;
            this.display = display;
            automat.IngrOverEvent += OnIngridientOver;
        }
        private void OnIngridientOver(object sender, IngridientsOverEventArgs args)
        { 
           List<Ingridient> ings = args.Ingridients;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ings.Count; ++i)
            {
                sb.AppendLine("\nOvered - " + ings[i].Name);
            }
            Logger.RecordMessageToLog(sb.ToString());
        }
    }
}
