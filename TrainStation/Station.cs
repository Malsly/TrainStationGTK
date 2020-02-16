using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainStation
{
    public class Station
    {
        private List<Train> trainList = new List<Train>();
        private List<Passanger> passangerList = new List<Passanger>();

        public List<Train> TrainList   
        {
            get { return trainList; }    
        }

        public List<Passanger> PassangerList   
        {
            get { return passangerList; }     
        }

        public Station(List<Train> TrainList, List<Passanger> PassangerList)
        {
            this.trainList = TrainList;
            this.passangerList = PassangerList;
        }

        public Passanger RegestrationPassanger(string Name, string Telephone, string Email) {
            Passanger passanger = new Passanger(Name, Telephone, Email);
            passangerList.Add(passanger);
            return passanger;
        }

        public Train AddTrain(string PlaceDeparture, string PlaceArrival, Dictionary<string, DateTime> RouteAndDate, Dictionary<string, int> RouteAndPrice, List<Van> VanList) 
        {
            Train train = new Train(PlaceDeparture, PlaceArrival, RouteAndDate, RouteAndPrice, VanList);
            trainList.Add(train);
            return train;
        }

        public Train PickTrain(string PlaceDeparture, string PlaceArrival)
        {
            Train pickedTrain = TrainList.FirstOrDefault(i => i.PlaceDeparture == PlaceDeparture && i.PlaceArrival == PlaceArrival);
            return pickedTrain;
        }

        public Ticket GetTicket(Passanger passanger, Train PickedTrain, Van PickedVan, Seat PickedSeat, string PlaceArrival) 
        {
            int price = 46;
            return new Ticket(passanger, price, PickedVan, PickedTrain, PickedSeat, PlaceArrival);
        }
    }
}
