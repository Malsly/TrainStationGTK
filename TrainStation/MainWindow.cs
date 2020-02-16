using System;
using System.Collections.Generic;
using Gtk;
using TrainStation;

public partial class MainWindow : Gtk.Window
{
    static List<Train> TrainList = new List<Train>();
    static List<Passanger> PassangerList = new List<Passanger>();
    Station station = new Station(TrainList, PassangerList);


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
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

        Train KeivChernigiv = station.AddTrain("Kiev", "Chernigiv", new Dictionary<string, DateTime>(), RouteAndPriceKievChernigiv, new List<Van>());
        station.AddTrain("Kiev", "Lugansk", new Dictionary<string, DateTime>(), RouteAndPriceKievLugansk, new List<Van>());
        station.AddTrain("Lviv", "Kiev", new Dictionary<string, DateTime>(), RouteAndPriceLvivKiev, new List<Van>());
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
            Passanger passanger = station.RegestrationPassanger(name, telephone, email);
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


        Deb.Print(station.TrainList);
        Deb.Print(station.PassangerList);
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
        Train choosedTrain;
        RouteAndTrain.TryGetValue(this.TrainsListComboBox.ActiveText, out choosedTrain);
        Deb.Print(choosedTrain);
    
    }

    protected void OnChoosVanComboBoxChanged(object sender, EventArgs e)
    {
        string choosedTrain = this.TrainsListComboBox.ActiveText;


        string choosedVan = this.ChoosVanComboBox.ActiveText;
        this.ChooseSeatComboBox.Show();
    }

    protected void OnChooseSeatComboBoxChanged(object sender, EventArgs e)
    {
        string choosedSeat = this.ChooseSeatComboBox.ActiveText;
        this.TicketingBtn.Show();
    }
}
