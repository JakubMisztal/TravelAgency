using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Travel_Agency_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Manager manager = new Manager();
         Printer printer = new Printer();
            manager.loadHotels();
            manager.generateOffers();

            do
            {
                printer.welcome();

                for (int p = 0; p < 3; p++)
            {
                printer.print_offer(manager.offers[p]);
            }

                if (manager.ischoiceValid() == false) printer.infoError();
                printer.ask();
                manager.takeAnswer();
                Console.Clear();
            }while (manager.ischoiceValid()==false);

            manager.offers[manager.choice].getPeople();
            
            printer.showFinalprice(manager.offers[manager.choice].finalPrice);
            
        Console.ReadKey();
        }
    }
}
