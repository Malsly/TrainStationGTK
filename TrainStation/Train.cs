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
        private Dictionary<string, DateTime> routeAndDate { get; set; }
        private Dictionary<string, int> routeAndPrice = new Dictionary<string, int>();
        private List<Van> VanList { get; set; }

        public string PlaceDeparture   // property
        {
            get { return placeDeparture; }   // get method
            set { placeDeparture = value; }
        }

        public string PlaceArrival   // property
        {
            get { return placeArrival; }   // get method
            set { placeArrival = value; }
        }

        public Dictionary<string, int> RouteAndPrice   // property
        {
            get { return routeAndPrice; }   // get method
        }

        public Dictionary<string, DateTime> RouteAndDate   // property
        {
            get { return routeAndDate; }   // get method
        }

        public Train(string PlaceDeparture, string PlaceArrival, Dictionary<string, DateTime> RouteAndDate, Dictionary<string, int> RouteAndPrice, List<Van> VanList)
        {
            this.PlaceDeparture = PlaceDeparture;
            this.PlaceArrival = PlaceArrival;
            this.routeAndPrice = RouteAndPrice;
            this.routeAndDate = RouteAndDate;
            this.VanList = VanList;
        }

        public void AddRouteAndPrice(string city, int price) 
        {
            routeAndPrice.Add(city, price);
        }

        public void AddRouteAndDate(string city, DateTime dateTime)
        {
            routeAndDate.Add(city, dateTime);
        }

        public Van PickVan(List<Seat> SeatList, string Class, int Number)
        {
            Van pickedVan = VanList.FirstOrDefault(i => i.Class == Class&& i.Number == Number);
            return pickedVan;
        }
    }
}
