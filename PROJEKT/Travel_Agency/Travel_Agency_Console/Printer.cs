using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Agency_Console
{
    internal class Printer
    {
        public void welcome()
        {
            Console.WriteLine("DZISIEJSZE PROMOWANE OFERTY");
            Console.WriteLine("------------------------------------");
        }
        public void ask()
        {
            Console.WriteLine("PROSZĘ PODAĆ NUMER WYBRANEJ OFERTY:");
        }
        
        public void print_offer(Offer x)
        {
            Console.WriteLine($"NUMER: {x.id}");
            Console.WriteLine($"KRAJ: {x.hotel.country}");

            Console.WriteLine($"TERMIN: {x.departureDate.ToShortDateString()} - {x.returnDate.ToShortDateString()} ({x.stay_length} dni)");
            
            Console.Write($"HOTEL: {x.hotel.name} (");
            for (int i = 0; i < x.hotel.stars; i++){
                Console.Write("*");
            }
            Console.WriteLine(")");

            if (x.is_allinclusive == true) Console.WriteLine("WYŻYWIENIE: All Inclusive");
            else Console.WriteLine("WYŻYWIENIE: Śniadania");
            
            Console.WriteLine($"CENA:{x.Price} PLN/os");
            
            
            Console.WriteLine("------------------------------------");
        }
    

        public void showFinalprice(decimal y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Pełna cena wynosi {y} PLN");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Do widzenia");
        }
    
        public void infoError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!!!BŁĄD!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    
    
    
    }
}
