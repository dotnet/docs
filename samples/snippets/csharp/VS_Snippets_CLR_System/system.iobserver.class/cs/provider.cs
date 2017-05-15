using System;
using System.Collections.Generic;

// <Snippet5>
public struct Location
{
   double lat, lon;

   public Location(double latitude, double longitude)
   {
      this.lat = latitude;
      this.lon = longitude;
   }

   public double Latitude
   { get { return this.lat; } }

   public double Longitude
   { get { return this.lon; } }
}
// </Snippet5>

// <Snippet6>
public class LocationTracker : IObservable<Location>
{
   public LocationTracker()
   {
      observers = new List<IObserver<Location>>();
   }

   // <Snippet13>
   private List<IObserver<Location>> observers;

   public IDisposable Subscribe(IObserver<Location> observer) 
   {
      if (! observers.Contains(observer)) 
         observers.Add(observer);
      return new Unsubscriber(observers, observer);
   }

   private class Unsubscriber : IDisposable
   {
      private List<IObserver<Location>>_observers;
      private IObserver<Location> _observer;

      public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
      {
         this._observers = observers;
         this._observer = observer;
      }

      public void Dispose()
      {
         if (_observer != null && _observers.Contains(_observer))
            _observers.Remove(_observer);
      }
   }
   // </Snippet13>

   public void TrackLocation(Nullable<Location> loc)
   {
      foreach (var observer in observers) {
         if (! loc.HasValue)
            observer.OnError(new LocationUnknownException());
         else
            observer.OnNext(loc.Value);
      }
   }

   public void EndTransmission()
   {
      foreach (var observer in observers.ToArray())
         if (observers.Contains(observer))
            observer.OnCompleted();

      observers.Clear();
   }
}
// </Snippet6>

// <Snippet7>
public class LocationUnknownException : Exception
{
   internal LocationUnknownException() 
   { }
}
// </Snippet7>
