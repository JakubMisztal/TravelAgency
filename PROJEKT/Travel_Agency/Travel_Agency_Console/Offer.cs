using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Agency_Console
{
    internal class Offer
    {
        public int id { get; set; }
        public Hotel hotel { get; set; }
        public int stay_length { get; set; }
        public bool is_allinclusive { get; set; }

        public DateTime departureDate {
            get
            {
                return new DateTime(2022,6,15);
            }
        }

        public DateTime returnDate { get
            {
                return departureDate.AddDays(stay_length);
            } 
        }

        public decimal Price { 
            get
            {
                decimal price = hotel.ppd * stay_length;
                if (is_allinclusive == true) price = price + 1200;

                if (hotel.country == "Hiszpania" || hotel.country == "Grecja") price = price + 1000;
                if (hotel.country == "Egipt") price = price + 1500;
                if (hotel.country == "Tajlandia") price = price + 2000;
                if (hotel.country == "Meksyk") price = price + 2500;

                return price;
            }
        }

        public int adults { get; set; }
        public int children { get; set; }


        public decimal finalPrice
        {
            get{ 
            return Price * children * 0.5m + Price * adults;
            }
        }

        public void getPeople()     //metoda pobiera od użytkownika ilość dorosłych i dzieci
        {
            Printer temp_printer = new Printer();
            int temp_int=0;
            string temp_string;
            bool canbeParsed=true;

            do{
                if (temp_int < 0 || canbeParsed == false) temp_printer.infoError();
                Console.WriteLine("Podaj ilość dorosłych: ");
                temp_string = Console.ReadLine();
                canbeParsed = Int32.TryParse(temp_string, out temp_int);
                Console.Clear();
            }while(temp_int<0 || canbeParsed==false);
            adults = temp_int;


            temp_int = 0;
            do{
                if (temp_int < 0 || canbeParsed == false) temp_printer.infoError();
                Console.WriteLine("Podaj ilość dzieci: ");
                temp_string = Console.ReadLine();
                canbeParsed = Int32.TryParse(temp_string, out temp_int);
                Console.Clear();
            }while(temp_int<0 || canbeParsed==false);
            children = temp_int;
        }

        public Offer(Hotel x, int o_id, int o_stay_length, bool o_is_allinclusive)
        {
            id = o_id;
            hotel = x;
            stay_length = o_stay_length;
            is_allinclusive = o_is_allinclusive;
        }
        public Offer() { }

    }
}
