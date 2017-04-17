//<Snippet1>
using System;
using System.Device.Location;

namespace GetLocationProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            GetLocationProperty();
        }

//<Snippet2>
        static void GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            
            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                Console.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
            }
        }
//</Snippet2>
    }
}
//</Snippet1>