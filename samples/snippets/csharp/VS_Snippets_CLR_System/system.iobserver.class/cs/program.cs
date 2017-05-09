// <Snippet9>
using System;

class Program
{
   static void Main(string[] args)
   {
      // Define a provider and two observers.
      LocationTracker provider = new LocationTracker();
      LocationReporter reporter1 = new LocationReporter("FixedGPS");
      reporter1.Subscribe(provider);
      LocationReporter reporter2 = new LocationReporter("MobileGPS");
      reporter2.Subscribe(provider);

      provider.TrackLocation(new Location(47.6456, -122.1312));
      reporter1.Unsubscribe();
      provider.TrackLocation(new Location(47.6677, -122.1199));
      provider.TrackLocation(null);
      provider.EndTransmission();
   }
}
// The example displays output similar to the following:
//      FixedGPS: The current location is 47.6456, -122.1312
//      MobileGPS: The current location is 47.6456, -122.1312
//      MobileGPS: The current location is 47.6677, -122.1199
//      MobileGPS: The location cannot be determined.
//      The Location Tracker has completed transmitting data to MobileGPS.
// </Snippet9>
