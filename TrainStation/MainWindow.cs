using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;
using TrainStation;
using TrainStation.DataAccess;

public partial class MainWindow : Gtk.Window
{
    Seat choosedSeat;
    Van choosedVan;
    Train choosedTrain;
    Passanger passanger;

    Station station = InitalizateData.InitalizationData();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
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
            this.TrainsTextView.Show();
            foreach (Train train in station.TrainList) 
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
            this.TrainsTextView.Hide();
        }
    }

    protected void OnTrainsListComboBoxChanged(object sender, EventArgs e)
    {
        Dictionary<string, Train> RouteAndTrain = new Dictionary<string, Train>();
        RouteAndTrain.Clear();
        this.ChoosVanComboBox.Show();
        this.VansTextView.Show();
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
        this.SeatTextView.Show();

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
