using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Domain.Core.ClientSide
{
    public class Logger
    {
        private static object objLock = new object();
        public static void RecordMessageToLog(string message)
        {
            lock (objLock)
            {
                using (StreamWriter writer = new StreamWriter("AutomatEventLog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} : {1}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), message));
                    writer.Flush();
                }
            }
        }
        public static void RecordEventToLog(string name, string messageEvent)
        {
            lock (objLock)
            {
                using (StreamWriter writer = new StreamWriter("AutomatEventLog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} : {1}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"),  name,messageEvent));
                    writer.Flush();
                }
            }
        }
        public static void RecordToProgramLog(string message)
        {
            lock (objLock)
            {
                using (StreamWriter writer = new StreamWriter("AppLog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} : {1}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), message));
                    writer.Flush();
                }
            }
        }
    }
}

