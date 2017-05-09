//<snippet1>
using System;
using System.Device.Location;
namespace ResolveAddressSync
{
    class Program
    {
        public static void Main(string[] args)
        {
            ResolveAddressAsync();
        }
        //<snippet2>
        static void ResolveAddressAsync()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            bool started = false;
            watcher.MovementThreshold = 1.0; // set to one meter
            started = watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            if (started)
            {
                CivicAddressResolver resolver = new CivicAddressResolver();

                resolver.ResolveAddressCompleted += new EventHandler<ResolveAddressCompletedEventArgs>(resolver_ResolveAddressCompleted);

                if (watcher.Position.Location.IsUnknown == false)
                {
                    resolver.ResolveAddressAsync(watcher.Position.Location);
                }
            }

        }

        static void resolver_ResolveAddressCompleted(object sender, ResolveAddressCompletedEventArgs e)
        {
            if (!e.Address.IsUnknown)
            {
                Console.WriteLine("Country: {0}, Zip: {1}",
                           e.Address.CountryRegion,
                           e.Address.PostalCode);
            }
            else
            {
                Console.WriteLine("Unknown address.");
            }
        }

        //</snippet2>

    }
}
//</snippet1>