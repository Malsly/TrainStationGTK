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


        Deb.Print(station.RegestrationPassanger(name, telephone, email));
    }
}
