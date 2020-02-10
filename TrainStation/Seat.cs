using System;
namespace TrainStation
{
    public class Seat
    {
        private int number { get; set; }
        private string type { get; set; }
        private Boolean isOccupied { get; set; }

        public int Number   // property
        {
            get { return number; }   // get method
            set { number = value; }
        }

        public string Type   // property
        {
            get { return type; }   // get method
            set { type = value; }
        }

        public Boolean IsOccuped   // property
        {
            get { return isOccupied; }   // get method
            set { isOccupied = value; }
        }

        public Seat(int Number, string Type, Boolean IsOccuped)
        {
            this.Number = Number;
            this.Type = Type;
            this.IsOccuped = IsOccuped;
        }
    }
}
