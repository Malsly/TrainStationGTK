using System;
using System.Collections.Generic;

namespace TrainStation
{
    public class Train
    {
        private string PlaceDeparture { get; set; }
        private string PlaceArrival { get; set; }
        private Dictionary<string, DateTime> RouteAndDate { get; set; }
        private Dictionary<string, int> RouteAndPrice { get; set; }
        private List<Van> VanList { get; set; }

        public Train(string PlaceDeparture, string PlaceArrival, Dictionary<string, DateTime> RouteAndDate, Dictionary<string, int> RouteAndPrice, List<Van> VanList)
        {
            this.PlaceDeparture = PlaceDeparture;
            this.PlaceArrival = PlaceArrival;
            this.RouteAndDate = RouteAndDate;
            this.VanList = VanList;
        }

        public Van PickVan()
        {
            return new Van(new List<Seat>(), "none", 0);
        }
    }
}
