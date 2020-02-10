using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainStation
{
    public class Van
    {
        private List<Seat> seatList { get; set; }
        private string classVan { get; set; }
        private int number { get; set; }

        public List<Seat> SeatList   // property
        {
            get { return seatList; }   // get method
            set { seatList = value; }
        }

        public string Class   // property
        {
            get { return classVan; }   // get method
            set { classVan = value; }
        }

        public int Number   // property
        {
            get { return number; }   // get method
            set { number = value; }
        }

        public Van(List<Seat> SeatList, string Class, int Number )
        {
            this.SeatList = SeatList;
            this.Class = Class;
            this.Number = Number;
        }

        public Seat PickSeat(int Number, string Type)
        {
            Seat pickedSeat = SeatList.FirstOrDefault(i => i.Number == Number && i.Type == Type && !i.IsOccupied);
            return pickedSeat;
        }
    }
}
