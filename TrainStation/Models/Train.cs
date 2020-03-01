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
        private List<Van> vanList { get; set; }

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

        public List<Van> VanList   // property
        {
            get { return vanList; }   // get method
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
            this.vanList = VanList;
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

        public void CreateVansForTrain(int countOfVans, string classOfVans) 
        {
            int lastNumberOfVan = 0;
            if (vanList.Count != 0) lastNumberOfVan = vanList[vanList.Count - 1].Number + 1;
             for (int i = lastNumberOfVan; i < lastNumberOfVan + countOfVans; i++) 
             {
                AddVan(new List<Seat>(), classOfVans, i);
             }
        }

        public void AddVan(List<Seat> seatList, string classVan, int number) 
        {
            VanList.Add(new Van(seatList, classVan, number));
        }
    }
}
