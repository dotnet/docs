//<snippet1>
using System;
using System.Device.Location;
namespace ShowStatusUpdates
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowStatusUpdates();
        }

        static void ShowStatusUpdates()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.Start();

            watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);

            Console.WriteLine("Enter any key to quit.");
            Console.ReadLine();

        }

        static void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Initializing:
                    Console.WriteLine("Working on location fix");
                    break;

                case GeoPositionStatus.Ready:
                    Console.WriteLine("Have location");
                    break;

                case GeoPositionStatus.NoData:
                    Console.WriteLine("No data");
                    break;

                case GeoPositionStatus.Disabled:
                    Console.WriteLine("Disabled");
                    break;
            }
        }

    }
}
//</snippet1>