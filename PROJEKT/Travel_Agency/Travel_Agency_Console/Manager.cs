using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Travel_Agency_Console
{
    internal class Manager
    {
       
        
        public List<Hotel> hotels = new List<Hotel>();
        public List<Offer> offers = new List<Offer>();
        public int choice { get; set; }
        public List<int> choices = new List<int> { 0, 1, 2 };
        

        public void loadHotels()    //metoda pobiera obiekty klasy Hotel z pliku o formacie ".json" i zapisuje je w liście
        {
            
            string filename = "list_of_hotels.json";
            string json_str = File.ReadAllText(filename);
            hotels = JsonConvert.DeserializeObject<List<Hotel>>(json_str);
        }

        public static List<int> GetNumbers()    //metoda zwraca listę zawierającą 3 losowe liczby z zakresu (0,5)
        {
            var numbers = new List<int>();
            var random = new Random();
            while (numbers.Count < 3)
            {
                int number = random.Next(0, 5);
                if (!numbers.Contains(number))
                    numbers.Add(number);
            }
            return numbers;
        }


        public void generateOffers()                                        //metoda generuje 3 losowe oferty (każda z tych trzech ofert ma hotel z innego kraju,
        {                                                                   //o różnej ilości gwiazdek, dodatkowo długość pobytu dla każdej z ofert jest inna, dwie oferty są all-inclusive)

            var numbers = GetNumbers();
            offers.Add(new Offer(hotels[numbers[0]*3], 1,  7, false));
            offers.Add(new Offer(hotels[numbers[1]*3+1], 2, 10, true));
            offers.Add(new Offer(hotels[numbers[2]*3+2], 3, 14, true));
        }
        
        public void takeAnswer()        //metoda pobiera od użytkownika odpowiedź (jeżeli odpowiedzi nie można przekonwertować na liczbę typu int to wybór zostanie ustawiony na -1)
        {
            
            string temp_string;
            int temp_int=0;
            bool canbeParsed;
            
            temp_string = Console.ReadLine();
            canbeParsed = Int32.TryParse(temp_string, out temp_int);
            temp_int--;

            choice = temp_int;
        }
    
        public bool ischoiceValid()     //metoda sprawdza, czy użytkownik poprawnie wybrał ofertę
        {
            if(choices.Contains(choice)) return true;
            else return false;
        }
        

    }
}
 
