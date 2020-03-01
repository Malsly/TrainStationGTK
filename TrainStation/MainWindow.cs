using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;
using TrainStation;

public partial class MainWindow : Gtk.Window
{
    static List<Train> TrainList = new List<Train>();
    static List<Passanger> PassangerList = new List<Passanger>();
    Station station = new Station(TrainList, PassangerList);

    Seat choosedSeat;
    Van choosedVan;
    Train choosedTrain;
    Passanger passanger;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        //Dictionary<string, int> RouteAndPriceKievChernigiv = new Dictionary<string, int>
        //{
        //    { "Kiev", 0 },
        //    { "Kozelets", 30 },
        //    { "Desna", 60},
        //    { "Chernigiv", 100 }
        //};

        //Dictionary<string, int> RouteAndPriceKievLugansk = new Dictionary<string, int>
        //{
        //    { "Kiev", 0 },
        //    { "Kozelets", 30 },
        //    { "Charkiv", 45 },
        //    { "Zhitomir", 75 },
        //    { "Lugansk", 130 }
        //};

        //Dictionary<string, int> RouteAndPriceLvivKiev = new Dictionary<string, int>
        //{
        //    { "Lviv", 0 },
        //    { "Gorodishe", 90 },
        //    { "Donetsk", 145 },
        //    { "Pomoshna", 275 },
        //    { "Kiev", 330 }
        //};

        //Dictionary<string, DateTime> RouteAndDateKievChernigiv = new Dictionary<string, DateTime>
        //{
        //    { "Kiev", DateTime.Now  },
        //    { "Kozelets", DateTime.Now + new TimeSpan(0, 3, 0, 0) },
        //    { "Desna", DateTime.Now + new TimeSpan(0, 4, 0, 0) },
        //    { "Chernigiv", DateTime.Now + new TimeSpan(1, 0, 0, 0) }
        //};

        //Dictionary<string, DateTime> RouteAndDateKievLugansk = new Dictionary<string, DateTime>
        //{
        //    { "Kiev", DateTime.Now  },
        //    { "Kozelets", DateTime.Now + new TimeSpan(0, 3, 0, 0) },
        //    { "Charkiv", DateTime.Now + new TimeSpan(1, 0, 0, 0) },
        //    { "Zhitomir", DateTime.Now + new TimeSpan(1, 5, 0, 0) },
        //    { "Lugansk", DateTime.Now + new TimeSpan(1, 13, 0, 0) }
        //};

        //Dictionary<string, DateTime> RouteAndDateLvivKiev = new Dictionary<string, DateTime>
        //{
        //    { "Lviv", DateTime.Now },
        //    { "Gorodishe", DateTime.Now + new TimeSpan(0, 3, 0, 0) },
        //    { "Donetsk", DateTime.Now + new TimeSpan(0, 8, 0, 0) },
        //    { "Pomoshna", DateTime.Now + new TimeSpan(0, 16, 0, 0) },
        //    { "Kiev", DateTime.Now + new TimeSpan(1, 3, 0, 0) }
        //};

        //List<Dictionary<string, DateTime>> RoutesAndDates = new List<Dictionary<string, DateTime>> 
        //{
        //    {RouteAndDateKievChernigiv},
        //    {RouteAndDateKievLugansk},
        //    {RouteAndDateLvivKiev} 
        //};

        //List<Dictionary<string, int>> RoutesAndPrices = new List<Dictionary<string, int>>
        //{
        //    {RouteAndPriceKievChernigiv},
        //    {RouteAndPriceKievLugansk},
        //    {RouteAndPriceLvivKiev}
        //};

        SerailizationAndDeserealization ser = new SerailizationAndDeserealization();
        //ser.SerializeListRoutesAndDates("RoutesAndDates.json", RoutesAndDates);
        //ser.SerializeListRoutesAndPrices("RoutesAndPrices.json", RoutesAndPrices);

        //ser.SerializeRouteAndPrice("RouteAndPriceKievChernigiv.json", RouteAndPriceKievChernigiv);
        //ser.SerializeRouteAndPrice("RouteAndPriceKievLugansk.json", RouteAndPriceKievLugansk);
        //ser.SerializeRouteAndPrice("RouteAndPriceLvivKiev.json", RouteAndPriceLvivKiev);

        //ser.SerializeRouteAndDate("RouteAndDateKievChernigiv.json", RouteAndDateKievChernigiv);
        //ser.SerializeRouteAndDate("RouteAndDateKievLugansk.json", RouteAndDateKievLugansk);
        //ser.SerializeRouteAndDate("RouteAndDateLvivKiev.json", RouteAndDateLvivKiev);

        var RoutesAndDates = ser.DeserializeListRoutesAndDates("RoutesAndDates.json");
        var RoutesAndPrices = ser.DeserializeListRoutesAndPrices("RoutesAndPrices.json");

        //var RouteAndPriceKievChernigiv = ser.DeserializeRouteAndPrice("RouteAndPriceKievChernigiv.json");
        //var RouteAndPriceKievLugansk = ser.DeserializeRouteAndPrice("RouteAndPriceKievLugansk.json");
        //var RouteAndPriceLvivKiev = ser.DeserializeRouteAndPrice("RouteAndPriceLvivKiev.json");

        //var RouteAndDateKievChernigiv = ser.DeserializeRouteAndDate("RouteAndDateKievChernigiv.json");
        //var RouteAndDateKievLugansk = ser.DeserializeRouteAndDate("RouteAndDateKievLugansk.json");
        //var RouteAndDateLvivKiev = ser.DeserializeRouteAndDate("RouteAndDateLvivKiev.json");

        var DatesAndPrices = RoutesAndDates.Zip(RoutesAndPrices, (n, w) => new { Routes = n, Prices = w });

        foreach (var rp in DatesAndPrices)
        {
            station.AddTrain(rp.Routes.Keys.First(), rp.Routes.Keys.Last(), rp.Routes, rp.Prices, new List<Van>());
        }

        foreach(Train train in station.TrainList) 
        {
            train.CreateVansForTrain(10, "Plackart");
            train.CreateVansForTrain(2, "Cupe");
            foreach(Van van in train.VanList) 
            {
                van.CreateSeatForVan(3, "Main");
                van.CreateSeatForVan(3, "Side");
            }
        }

        Van.AddClassAndPrice("Plackart", 0);
        Van.AddClassAndPrice("Cupe", 20);

        Seat.AddTypeAndPrice("Main", 0);
        Seat.AddTypeAndPrice("Side", 0);

        //Deb.Print(station.TrainList[0].VanList[0].SeatList);

        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnRegestrationClicked(object sender, EventArgs e)
    {
        string name = this.NamePassanger.Text;
        string telephone = this.Telephone.Text;
        string email = this.Email.Text;

        if (Passanger.IsValidUser(name, telephone, email)) 
        {
            passanger = station.RegestrationPassanger(name, telephone, email);
            this.Place.Show();
            this.PlaceTextView.Show();
            this.ChooseTrainBtn.Show();
        }
        else {
            this.TextAttention.Buffer.Text = "Not valid user";
            this.Place.Hide();
            this.PlaceTextView.Hide();
            this.ChooseTrainBtn.Hide();
        }


        //Deb.Print(station.TrainList);
        //Deb.Print(station.PassangerList);
    }

    protected void OnChooseTrainClicked(object sender, EventArgs e)
    {
        ListStore DataSourceForTrains = new ListStore(typeof(string), typeof(Train));
        this.TrainsListComboBox.Model = DataSourceForTrains;

        string placeDepartureText = this.placeDeparture.Text;
        string placeArrivalText = this.placeArrival.Text;

        if (placeArrivalText != "" && placeDepartureText != "")
        {
            this.TrainsListComboBox.Show();
            foreach(Train train in station.TrainList) 
            {
                if(train.PlaceDeparture.Contains(placeDepartureText) && train.RouteAndPrice.ContainsKey(placeArrivalText)) 
                {
                    if (train.PlaceArrival == placeArrivalText) 
                    {
                        DataSourceForTrains.AppendValues($"{train.PlaceDeparture} - {train.PlaceArrival}", train);
                    }
                    else { 
                        DataSourceForTrains.AppendValues($"{train.PlaceDeparture} - {placeArrivalText} - {train.PlaceArrival}", train);

                    } 
                }
            }
        }
        else
        {
            this.TrainsListComboBox.Hide();
        }
    }

    protected void OnTrainsListComboBoxChanged(object sender, EventArgs e)
    {
        Dictionary<string, Train> RouteAndTrain = new Dictionary<string, Train>();
        RouteAndTrain.Clear();
        this.ChoosVanComboBox.Show();

        TreeIter iter;
        if (this.TrainsListComboBox.Model.GetIterFirst(out iter))
        {
            do
            {
                RouteAndTrain.Add((string)this.TrainsListComboBox.Model.GetValue(iter, 0), (Train)this.TrainsListComboBox.Model.GetValue(iter, 1));
            } while (this.TrainsListComboBox.Model.IterNext(ref iter));
        }

        RouteAndTrain.TryGetValue(this.TrainsListComboBox.ActiveText, out choosedTrain);


        ListStore DataSourceForVans = new ListStore(typeof(int), typeof(Van));
        this.ChoosVanComboBox.Model = DataSourceForVans;

        foreach(Van van in choosedTrain.VanList) 
        {
            DataSourceForVans.AppendValues(van.Number, van); 
        }

    }

    protected void OnChoosVanComboBoxChanged(object sender, EventArgs e)
    {
        Dictionary<int, Van> NumberAndVan = new Dictionary<int, Van>();

        TreeIter iter;
        if (this.ChoosVanComboBox.Model.GetIterFirst(out iter))
        {
            do
            {
                NumberAndVan.Add((int)this.ChoosVanComboBox.Model.GetValue(iter, 0), (Van)this.ChoosVanComboBox.Model.GetValue(iter, 1));
            } while (this.ChoosVanComboBox.Model.IterNext(ref iter));
        }

        NumberAndVan.TryGetValue(Convert.ToInt32(this.ChoosVanComboBox.Active), out choosedVan);

        Deb.Print(choosedVan.Number);

        this.ChooseSeatComboBox.Show();

        ListStore DataSourceForSeats = new ListStore(typeof(int), typeof(Seat));
        this.ChooseSeatComboBox.Model = DataSourceForSeats;

        foreach (Seat seat in choosedVan.SeatList)
        {
            if (seat.IsOccuped == false) 
            {
                DataSourceForSeats.AppendValues(seat.Number, seat);
            }
        }
    }

    protected void OnChooseSeatComboBoxChanged(object sender, EventArgs e)
    {
        Dictionary<int, Seat> NumberAndSeat = new Dictionary<int, Seat>();

        TreeIter iter;
        if (this.ChooseSeatComboBox.Model.GetIterFirst(out iter))
        {
            do
            {
                NumberAndSeat.Add((int)this.ChooseSeatComboBox.Model.GetValue(iter, 0), (Seat)this.ChooseSeatComboBox.Model.GetValue(iter, 1));
            } while (this.ChooseSeatComboBox.Model.IterNext(ref iter));
        }

        NumberAndSeat.TryGetValue(Convert.ToInt32(this.ChooseSeatComboBox.Active), out choosedSeat);

        //Deb.Print(choosedSeat.Number);

        this.TicketingBtn.Show();
    }

    protected void OnTicketingBtnClicked(object sender, EventArgs e)
    {
        string placeArrivalText = this.placeArrival.Text;
        int priceForRoute;
        int priceForVanClass;
        int priceForSeatType;
        choosedTrain.RouteAndPrice.TryGetValue(placeArrivalText, out priceForRoute);
        Van.ClassAndPrice.TryGetValue(choosedVan.Class, out priceForVanClass);
        Seat.TypeAndPrice.TryGetValue(choosedSeat.Type, out priceForSeatType);

        int price = priceForRoute + priceForSeatType + priceForVanClass;

        choosedSeat.IsOccuped = true;

        Deb.Print(new Ticket(passanger, price, choosedVan, choosedTrain, choosedSeat, placeArrivalText));
    }
}
