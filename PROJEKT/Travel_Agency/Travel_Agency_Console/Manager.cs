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
        
        //public void loadHotels1()
        //{
        //    hotels.Add(new Hotel("Imperial Laguna by Faranda", "Meksyk", 3, 320));
        //    hotels.Add(new Hotel("Cancun Bay Resort", "Meksyk", 4, 450));
        //    hotels.Add(new Hotel("Iberostar Quetzal", "Meksyk", 5, 690));

        //    hotels.Add(new Hotel("Palia Puerto del Sol", "Hiszpania", 3, 240));
        //    hotels.Add(new Hotel("Playa Real Resort", "Hiszpania", 4, 380));
        //    hotels.Add(new Hotel("Playacalida", "Hiszpania", 5, 600));

        //    hotels.Add(new Hotel("Sea Gull", "Egipt", 3, 270));
        //    hotels.Add(new Hotel("Continental Hurghada", "Egipt", 4, 360));
        //    hotels.Add(new Hotel("Sharm Grand Plaza", "Egipt", 5, 620));

        //    hotels.Add(new Hotel("Ikaros Hotel", "Grecja", 3, 220)); 
        //    hotels.Add(new Hotel("Lida Corfu", "Grecja", 4, 310));
        //    hotels.Add(new Hotel("Labranda Sandy Beach Resort", "Grecja", 5, 580));

        //    hotels.Add(new Hotel("Cholchan Pattaya Resort", "Tajlandia", 3, 290)); 
        //    hotels.Add(new Hotel("Novotel Rayong", "Tajlandia", 4, 410));
        //    hotels.Add(new Hotel("Mytt Beach Hotel", "Tajlandia", 5, 720));
        //}

        public void loadHotels()
        {
            
            string filename = "list_of_hotels.json";
            string json_str = File.ReadAllText(filename);
            hotels = JsonConvert.DeserializeObject<List<Hotel>>(json_str);
        }

        public static List<int> GetNumbers()
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


        public void generateOffers()
        {
            
            var numbers = GetNumbers();
            offers.Add(new Offer(hotels[numbers[0]*3], 1,  7, false));
            offers.Add(new Offer(hotels[numbers[1]*3+1], 2, 10, true));
            offers.Add(new Offer(hotels[numbers[2]*3+2], 3, 14, true));
        }
        
        public void takeAnswer()
        {
            
            string temp_string;
            int temp_int=0;
            bool canbeParsed;
            
            temp_string = Console.ReadLine();
            canbeParsed = Int32.TryParse(temp_string, out temp_int);
            temp_int--;

            choice = temp_int;
        }
    
        public bool ischoiceValid()
        {
            if(choices.Contains(choice)) return true;
            else return false;
        }
        

    }
}
 
