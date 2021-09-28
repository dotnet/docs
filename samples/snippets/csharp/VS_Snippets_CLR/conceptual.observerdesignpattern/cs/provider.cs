// <Snippet1>
using System;
using System.Collections.Generic;

public class BaggageInfo
{
   private int flightNo;
   private string origin;
   private int location;

   internal BaggageInfo(int flight, string from, int carousel)
   {
      this.flightNo = flight;
      this.origin = from;
      this.location = carousel;
   }

   public int FlightNumber {
      get { return this.flightNo; }
   }

   public string From {
      get { return this.origin; }
   }

   public int Carousel {
      get { return this.location; }
   }
}
// </Snippet1>

// <Snippet2>
public class BaggageHandler : IObservable<BaggageInfo>
{
   private List<IObserver<BaggageInfo>> observers;
   private List<BaggageInfo> flights;

   public BaggageHandler()
   {
      observers = new List<IObserver<BaggageInfo>>();
      flights = new List<BaggageInfo>();
   }

   public IDisposable Subscribe(IObserver<BaggageInfo> observer)
   {
      // Check whether observer is already registered. If not, add it
      if (! observers.Contains(observer)) {
         observers.Add(observer);
         // Provide observer with existing data.
         foreach (var item in flights)
            observer.OnNext(item);
      }
      return new Unsubscriber<BaggageInfo>(observers, observer);
   }

   // Called to indicate all baggage is now unloaded.
   public void BaggageStatus(int flightNo)
   {
      BaggageStatus(flightNo, String.Empty, 0);
   }

   public void BaggageStatus(int flightNo, string from, int carousel)
   {
      var info = new BaggageInfo(flightNo, from, carousel);

      // Carousel is assigned, so add new info object to list.
      if (carousel > 0 && ! flights.Contains(info)) {
         flights.Add(info);
         foreach (var observer in observers)
            observer.OnNext(info);
      }
      else if (carousel == 0) {
         // Baggage claim for flight is done
         var flightsToRemove = new List<BaggageInfo>();
         foreach (var flight in flights) {
            if (info.FlightNumber == flight.FlightNumber) {
               flightsToRemove.Add(flight);
               foreach (var observer in observers)
                  observer.OnNext(info);
            }
         }
         foreach (var flightToRemove in flightsToRemove)
            flights.Remove(flightToRemove);

         flightsToRemove.Clear();
      }
   }

   public void LastBaggageClaimed()
   {
      foreach (var observer in observers)
         observer.OnCompleted();

      observers.Clear();
   }
}
// </Snippet2>

// <Snippet3>
internal class Unsubscriber<BaggageInfo> : IDisposable
{
   private List<IObserver<BaggageInfo>> _observers;
   private IObserver<BaggageInfo> _observer;

   internal Unsubscriber(List<IObserver<BaggageInfo>> observers, IObserver<BaggageInfo> observer)
   {
      this._observers = observers;
      this._observer = observer;
   }

   public void Dispose()
   {
      if (_observers.Contains(_observer))
         _observers.Remove(_observer);
   }
}
// </Snippet3>
