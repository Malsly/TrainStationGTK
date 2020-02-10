using System;
namespace TrainStation
{
    public class Seat
    {
        private int Number { get; set; }
        private string Type { get; set; }
        private Boolean IsOccupied { get; set; }

        public Seat(int Number, string Type, Boolean IsOccupied)
        {
            this.Number = Number;
            this.Type = Type;
            this.IsOccupied = IsOccupied;
        }
    }
}
