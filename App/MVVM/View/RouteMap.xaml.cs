using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET.WindowsForms;
using MapControl;
using GMap.NET.WindowsPresentation;
using Microsoft.Maps.MapControl.WPF;
using Location = Microsoft.Maps.MapControl.WPF.Location;
using Pushpin = Microsoft.Maps.MapControl.WPF.Pushpin;
using GMap.NET.MapProviders;
using System.Net;
using GMap.NET;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para RouteMap.xaml
    /// </summary>
    public partial class RouteMap : UserControl
    {
        private int pinCount = 0;

        Pushpin pushpinInit = new Pushpin();
        Pushpin pushpinEnd = new Pushpin();

        public RouteMap()
        {
            InitializeComponent();

            MapInit();

        }

        void MapInit()
        {
            MyMap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            MyMap.Position = new PointLatLng(38.546465, -0.116349);
            MyMap.Zoom = 10;

        }

        //void makeRoute()
        //{
        //    Pushpin startPushpin = new Pushpin();
        //    startPushpin.Location = new Location(47.6062, -122.3321);
        //    myMap.Children.Add(startPushpin);
        //    Pushpin endPushpin = new Pushpin();
        //    endPushpin.Location = new Location(47.6062, -122.3321);
        //    myMap.Children.Add(endPushpin);

        //    Route route = new Route(startPushpin.Location, endPushpin.Location);
        //    route.Color = Colors.Red;
        //    route.Width = 5;
        //    MyMap.Children.Add(route);

        //}


        //private void myMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    var point = e.GetPosition(myMap);
        //    var location = myMap.ViewportPointToLocation(point);

        //    if (pinCount == 0)
        //    {
        //        pushpinInit.Location = location;
        //        pushpinInit.Location = new Location(38.546465, -0.116349);

        //        myMap.Children.Add(pushpinInit);
        //    }
        //    else if (pinCount == 1)
        //    {
        //        pushpinEnd.Location = location;
        //        pushpinEnd.Location = new Location(38.546465, -0.116349);

        //        myMap.Children.Add(pushpinEnd);
        //    }


        //    pinCount++;

        //}

        private void newRoute_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
