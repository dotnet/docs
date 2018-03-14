//<Snippet1>
using System;
using System.Device.Location;
namespace ResolveAddressSync
{
    class Program
    {
        static void Main(string[] args)
        {
            ResolveAddressSync();
        }
//<Snippet2>
        static void ResolveAddressSync()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.MovementThreshold = 1.0; // set to one meter
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            CivicAddressResolver resolver = new CivicAddressResolver();

            if (watcher.Position.Location.IsUnknown == false)
            {
                CivicAddress address = resolver.ResolveAddress(watcher.Position.Location);

                if (!address.IsUnknown)
                {
                    Console.WriteLine("Country: {0}, Zip: {1}",
                            address.CountryRegion,
                            address.PostalCode);
                }
                else
                {
                    Console.WriteLine("Address unknown.");
                }
            }
        }
//</Snippet2>

    }
}
//</Snippet1>
