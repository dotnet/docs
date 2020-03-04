//<Snippet1>
using System;
using System.Device.Location;

namespace GetLocationEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            CLocation myLocation = new CLocation();
            myLocation.GetLocationEvent();
            Console.WriteLine("Enter any key to quit.");
            Console.ReadLine();            
        }
//<Snippet2>
        class CLocation
        {
            GeoCoordinateWatcher watcher;

            public void GetLocationEvent()
            {
                this.watcher = new GeoCoordinateWatcher();
                this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
                if (!started)
                {
                    Console.WriteLine("GeoCoordinateWatcher timed out on start.");
                }
            }

            void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
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
