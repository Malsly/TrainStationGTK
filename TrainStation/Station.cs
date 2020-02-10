using System;
using System.Collections.Generic;

namespace TrainStation
{
    public class Station
    {
        private List<Train> TrainList { get; set; }
        private List<Passanger> PassangerList { get; set; }

        public Station(List<Train> TrainList, List<Passanger> PassangerList)
        {
            this.TrainList = TrainList;
            this.PassangerList = PassangerList;
        }

        public Passanger RegestrationPassanger(string Name, string Telephone, string Email) {
            Passanger passanger = new Passanger(Name, Telephone, Email);
            return passanger;
        }

        public Train PickTrain()
        {
            return new Train("none", "none", new Dictionary<string, DateTime>(), new Dictionary<string, int>(), new List<Van>() );
        }
    }
}
