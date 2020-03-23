using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainStation.DataAccess
{
    public class InitalizateData
    {
        public static Station InitalizationData()
        {
            List<Train> TrainList = new List<Train>();
            List<Passanger> PassangerList = new List<Passanger>();
            Station station = new Station(TrainList, PassangerList);

            SerailizationAndDeserealization ser = new SerailizationAndDeserealization();
            string configRoutesAndDates = Environment.GetEnvironmentVariable("RoutesAndDates");
            string configRoutesAndPrices = Environment.GetEnvironmentVariable("RoutesAndPrices");
            string configWithSerialize = Environment.GetEnvironmentVariable("WithSerialize");
            if (configWithSerialize == "False")
            {
                Deb.Print("Start without serialization");

                List<Dictionary<string, DateTime>> RoutesAndDates = ser.DeserializeListRoutesAndDates(configRoutesAndDates);
                List<Dictionary<string, int>> RoutesAndPrices = ser.DeserializeListRoutesAndPrices(configRoutesAndPrices);

                var DatesAndPrices = RoutesAndDates.Zip(RoutesAndPrices, (n, w) => new { Routes = n, Prices = w });

                foreach (var rp in DatesAndPrices)
                {
                    station.AddTrain(rp.Routes.Keys.First(), rp.Routes.Keys.Last(), rp.Routes, rp.Prices, new List<Van>());
                }

            }
            else
            {
                Deb.Print("Start with serialization");

                Dictionary<string, int> RouteAndPriceKievChernigiv = new Dictionary<string, int>
            {
                { "Kiev", 0 },
                { "Kozelets", 30 },
                { "Desna", 60},
                { "Chernigiv", 100 }
            };

                Dictionary<string, int> RouteAndPriceKievLugansk = new Dictionary<string, int>
            {
                { "Kiev", 0 },
                { "Kozelets", 30 },
                { "Charkiv", 45 },
                { "Zhitomir", 75 },
                { "Lugansk", 130 }
            };

                Dictionary<string, int> RouteAndPriceLvivKiev = new Dictionary<string, int>
            {
                { "Lviv", 0 },
                { "Gorodishe", 90 },
                { "Donetsk", 145 },
                { "Pomoshna", 275 },
                { "Kiev", 330 }
            };

                Dictionary<string, DateTime> RouteAndDateKievChernigiv = new Dictionary<string, DateTime>
            {
                { "Kiev", DateTime.Now  },
                { "Kozelets", DateTime.Now + new TimeSpan(0, 3, 0, 0) },
                { "Desna", DateTime.Now + new TimeSpan(0, 4, 0, 0) },
                { "Chernigiv", DateTime.Now + new TimeSpan(1, 0, 0, 0) }
            };

                Dictionary<string, DateTime> RouteAndDateKievLugansk = new Dictionary<string, DateTime>
            {
                { "Kiev", DateTime.Now  },
                { "Kozelets", DateTime.Now + new TimeSpan(0, 3, 0, 0) },
                { "Charkiv", DateTime.Now + new TimeSpan(1, 0, 0, 0) },
                { "Zhitomir", DateTime.Now + new TimeSpan(1, 5, 0, 0) },
                { "Lugansk", DateTime.Now + new TimeSpan(1, 13, 0, 0) }
            };

                Dictionary<string, DateTime> RouteAndDateLvivKiev = new Dictionary<string, DateTime>
            {
                { "Lviv", DateTime.Now },
                { "Gorodishe", DateTime.Now + new TimeSpan(0, 3, 0, 0) },
                { "Donetsk", DateTime.Now + new TimeSpan(0, 8, 0, 0) },
                { "Pomoshna", DateTime.Now + new TimeSpan(0, 16, 0, 0) },
                { "Kiev", DateTime.Now + new TimeSpan(1, 3, 0, 0) }
            };

                List<Dictionary<string, DateTime>> RoutesAndDates = new List<Dictionary<string, DateTime>>
            {
                {RouteAndDateKievChernigiv},
                {RouteAndDateKievLugansk},
                {RouteAndDateLvivKiev}
            };

                List<Dictionary<string, int>> RoutesAndPrices = new List<Dictionary<string, int>>
            {
                {RouteAndPriceKievChernigiv},
                {RouteAndPriceKievLugansk},
                {RouteAndPriceLvivKiev}
            };

                ser.SerializeListRoutesAndDates("RoutesAndDates.json", RoutesAndDates);
                ser.SerializeListRoutesAndPrices("RoutesAndPrices.json", RoutesAndPrices);

                ser.SerializeRouteAndPrice("RouteAndPriceKievChernigiv.json", RouteAndPriceKievChernigiv);
                ser.SerializeRouteAndPrice("RouteAndPriceKievLugansk.json", RouteAndPriceKievLugansk);
                ser.SerializeRouteAndPrice("RouteAndPriceLvivKiev.json", RouteAndPriceLvivKiev);

                ser.SerializeRouteAndDate("RouteAndDateKievChernigiv.json", RouteAndDateKievChernigiv);
                ser.SerializeRouteAndDate("RouteAndDateKievLugansk.json", RouteAndDateKievLugansk);
                ser.SerializeRouteAndDate("RouteAndDateLvivKiev.json", RouteAndDateLvivKiev);

                station.AddTrain("Kiev", "Chernigiv", RouteAndDateKievChernigiv, RouteAndPriceKievChernigiv, new List<Van>());
                station.AddTrain("Kiev", "Lugansk", RouteAndDateKievLugansk, RouteAndPriceKievLugansk, new List<Van>());
                station.AddTrain("Lviv", "Kiev", RouteAndDateLvivKiev, RouteAndPriceLvivKiev, new List<Van>());
            }

            foreach (Train train in station.TrainList)
            {
                train.CreateVansForTrain(10, "Plackart");
                train.CreateVansForTrain(2, "Cupe");
                foreach (Van van in train.VanList)
                {
                    van.CreateSeatForVan(3, "Main");
                    van.CreateSeatForVan(3, "Side");
                }
            }

            Van.AddClassAndPrice("Plackart", 0);
            Van.AddClassAndPrice("Cupe", 20);

            Seat.AddTypeAndPrice("Main", 0);
            Seat.AddTypeAndPrice("Side", 0);

            return station;
        }


    }
}
