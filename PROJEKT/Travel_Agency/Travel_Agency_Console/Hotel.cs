using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Agency_Console
{
    internal class Hotel
    {
        public string name { get; set; }
        public string country { get; set; }
        public int stars { get; set; }
        public decimal ppd { get; set; }            // ppd - price per day

        public Hotel(string h_name, string h_country, int h_stars, decimal h_ppd)
        {
            name = h_name;
            country = h_country;
            stars = h_stars;
            ppd = h_ppd;
        }
        public Hotel() { }
    
    }
}
