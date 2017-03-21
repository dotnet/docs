using System;
using System.Collections.Generic;
using System.Threading;

// <Snippet1>
public enum LocationStatus { Started = 1, EnRoute = 2, Finished = 3 };

public struct Location
{
   public readonly decimal Latitude;
   public readonly decimal Longitude;
   public readonly DateTime DateAndTime;
   public readonly LocationStatus Status;
         
   public Location(decimal lat, decimal lon, DateTime dateAndTime, LocationStatus status)
   {
      this.Latitude = lat;
      this.Longitude = lon;
      this.DateAndTime = dateAndTime;
      this.Status = status;
   }   
}
// </Snippet1>

// <Snippet3>
public class LocationSimulator : IObservable<Location>
{
   List<IObserver<Location>> observers = new List<IObserver<Location>>();
   Location _location, _lastLocation, _startLocation;
   
   public static LocationSimulator SetStartingLocation()
   {
      return new LocationSimulator(42.2857m, -83.7213m, LocationStatus.Started);
   }
         
   private LocationSimulator(decimal latitude, decimal longitude, LocationStatus status)
   {
      _location = new Location(latitude, longitude, DateTime.UtcNow, status);
      _lastLocation = _location;
      if (status == LocationStatus.Started)
         _startLocation = _location;
   }
   
   public Location Location 
   {
      get { return this._location; }
   }
   
   public Location GetCurrentLocation()
   {
      Random rnd = new Random();
      decimal newLat = _location.Latitude + rnd.Next(-1, 2);
      decimal newLong = _location.Longitude + rnd.Next(-1, 2);
      // Assume arrival if the difference in latitude is 3.   
      _lastLocation = _location;
      LocationStatus status = Math.Abs(_startLocation.Latitude - newLat) >= 3 ?
                  LocationStatus.Finished : LocationStatus.EnRoute;
      _location = new Location(_location.Latitude + rnd.Next(-1, 2),
                               _location.Longitude + rnd.Next(-1, 2), 
                               DateTime.UtcNow, status);
      if (! _location.Equals(_lastLocation))
      {
         // Notify observers.
         foreach (IObserver<Location> observer in observers)
         {
            observer.OnNext(this.Location);
            // Assume that we've arrived at location of Latitude has changed by 4.
            if (_location.Status == LocationStatus.Finished)
               observer.OnCompleted(); 
         }
      }      
      return this.Location;   
   }
   
   public IDisposable Subscribe(IObserver<Location> observer) 
   {
      observers.Add(observer);
      // Announce current location to new observer.
      observer.OnNext(this.Location);
      return observer as IDisposable;
   }
}
// </Snippet3>

// <Snippet2>
public class LocationDisplay : IObserver<Location>
{
   public void OnNext(Location value)
   {
      Console.WriteLine("{3}At {0}, Latitude = {1:N4}, Longitude = {2:N4}", value.DateAndTime, value.Latitude, value.Longitude,
                        value.Status == LocationStatus.Started ? "Starting " : "");
   }
   
   public void OnError(Exception error)
   { 
      Console.WriteLine("Unable to determine the current location.");          
   }
   
   public void OnCompleted() 
   {
      Console.WriteLine("Finished tracking the current location.");           
   }       
}
// </Snippet2>

// <Snippet4>
public class Example
{
   public static void Main()
   {
       LocationSimulator simulator = LocationSimulator.SetStartingLocation();
         
       // Subscribe with class that implements IObserver<Location>
       IDisposable d = simulator.Subscribe(new LocationDisplay());
       Location loc;
       do {
          loc = simulator.GetCurrentLocation();      
          Thread.Sleep(2500);
       } while (loc.Status != LocationStatus.Finished);  
   }
}
// </Snippet4>
