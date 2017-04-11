//<Snippet1>
using System;
using System.Device.Location;

namespace GetLocationDataUpdateOnce
{
    class Program
    {
        static void Main(string[] args)
        {
            CLocation myLocation = new CLocation();
            myLocation.GetLocationDataEvent();
            Console.WriteLine("Enter any key to quit.");
            Console.ReadLine();
        }
        //<Snippet2>
        class CLocation
        {
            GeoCoordinateWatcher watcher;

            public void GetLocationDataEvent()
            {
                this.watcher = new GeoCoordinateWatcher();
                this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                this.watcher.Start();
            }

            void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
                // Stop receiving updates after the first one.
                this.watcher.Stop();
            }

            void PrintPosition(double Latitude, double Longitude)
            {
                Console.WriteLine("Latitude: {0}, Longitude {1}", Latitude, Longitude);
            }
        }
        //</Snippet2>
    }
}
//</Snippet1>
