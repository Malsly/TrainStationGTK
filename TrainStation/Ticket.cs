using System;
namespace TrainStation
{
    public class Ticket
    {
        private Passanger passanger { get; set; }
        private int price { get; set; }
        private Van van { get; set; }
        private Train train { get; set; }
        private Seat seat { get; set; }
        private string placeArrival { get; set; }

        public Passanger Passanger
        {
            get { return passanger; }   // get method
        }
        public int Price
        {
            get { return price; }   // get method
        }
        public Van Van
        {
            get { return van; }   // get method
        }
        public Train Train
        {
            get { return train; }   // get method
        }
        public Seat Seat
        {
            get { return seat; }   // get method
        }
        public string PlaceArrival
        {
            get { return placeArrival; }   // get method
        }

        public Ticket(Passanger Passanger, int Price, Van Van, Train Train, Seat Seat, string PlaceArrival)
        {
            this.passanger = Passanger;
            this.price = Price;
            this.van = Van;
            this.train = Train;
            this.seat = Seat;
            this.placeArrival = PlaceArrival;
        }

        public Ticket SendToMail() 
        {
            return this; 
        }
    }
}
