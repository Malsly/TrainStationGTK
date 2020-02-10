using System;
using System.Collections.Generic;
using System.Linq;
using static TrainStation.Deb;

namespace TrainStation
{
    public class Train
    {
        private string placeDeparture { get; set; }
        private string placeArrival { get; set; }
        private Dictionary<string, DateTime> RouteAndDate { get; set; }
        private Dictionary<string, int> RouteAndPrice { get; set; }
        private List<Van> VanList { get; set; }

        public string PlaceDeparture   // property
        {
            get { return placeDeparture; }   // get method
            set { placeDeparture = value; }
        }

        public string PlaceArrival   // property
        {
            get { return placeArrival; }   // get method
            set{ placeArrival = value; }
        }

        public Train(string PlaceDeparture, string PlaceArrival, Dictionary<string, DateTime> RouteAndDate, Dictionary<string, int> RouteAndPrice, List<Van> VanList)
        {
            this.PlaceDeparture = PlaceDeparture;
            this.PlaceArrival = PlaceArrival;
            this.RouteAndDate = RouteAndDate;
            this.VanList = VanList;
        }

        public Van PickVan(List<Seat> SeatList, string Class, int Number)
        {
            Van pickedVan = VanList.FirstOrDefault(i => i.Class == Class&& i.Number == Number);
            return pickedVan;
        }
    }
}
