using System;
using System.Collections.Generic;

namespace TrainStation
{
    public class Seat
    {
        private int number { get; set; }
        private string type { get; set; }
        private Boolean isOccupied { get; set; }
        private static Dictionary<string, int> typeAndPrice = new Dictionary<string, int>();


        public static Dictionary<string, int> TypeAndPrice    // property
        {
            get { return typeAndPrice; }   // get method
        }

        public int Number   // property
        {
            get { return number; }   // get method
        }

        public string Type   // property
        {
            get { return type; }   // get method
        }

        public Boolean IsOccuped   // property
        {
            get { return isOccupied; }   // get method
            set { isOccupied = value; }
        }

        public Seat(int Number, string Type, Boolean IsOccuped)
        {
            this.number = Number;
            this.type = Type;
            this.IsOccuped = IsOccuped;
        }

        public static void AddTypeAndPrice(string type, int price) 
        {
            typeAndPrice.Add(type, price); 
        }

    }
}
