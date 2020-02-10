using System;
namespace TrainStation
{
    public class Ticket
    {
        private Passanger Passanger { get; set; }
        private int Price { get; set; }
        private Van Van { get; set; }
        private Train Train { get; set; }
        private Seat Seat { get; set; }
        private string PlaceArrival { get; set; }

        public Ticket(Passanger Passanger, int Price, Van Van, Train Train, Seat Seat, string PlaceArrival)
        {
            this.Passanger = Passanger;
            this.Price = Price;
            this.Van = Van;
            this.Train = Train;
            this.Seat = Seat;
            this.PlaceArrival = PlaceArrival;
        }

        public Ticket SendToMail() 
        {
            return this; 
        }
    }
}
