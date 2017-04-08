//<Snippet1>
using System;
using System.Device.Location;

namespace GetLocationPropertyHandleUnknown
{
    class Program
    {
        static void Main(string[] args)
        {
            GetLocationPropertyHandleUnknown();
        }

        //<Snippet2>
        static void GetLocationPropertyHandleUnknown()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            if (watcher.Position.Location.IsUnknown != true)
            {
                GeoCoordinate coord = watcher.Position.Location;

                Console.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
            }
            else
            {
                Console.WriteLine("Unknown");
            }

        }
        //</Snippet2>

    }
}
//</Snippet1>
