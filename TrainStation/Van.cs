using System;
using System.Collections.Generic;

namespace TrainStation
{
    public class Van
    {
        private List<Seat> SeatList { get; set; }
        private string Class { get; set; }
        private int Number { get; set; }

        public Van(List<Seat> SeatList, string Class, int Number )
        {
            this.SeatList = SeatList;
            this.Class = Class;
            this.Number = Number;
        }

        public Seat PickSeat()
        {
            return new Seat(0, "none", true);
        }
    }
}
