using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public class LodgingModel
    {
        public int IDLodging { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Location { get; set; }
        public int AdultAvailable { get; set; }
        public int KidAvailable { get; set; }
        public string Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
