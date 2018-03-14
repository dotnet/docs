// <Snippet8>
using System;

public class LocationReporter : IObserver<Location>
{
   private IDisposable unsubscriber;
   private string instName;

   public LocationReporter(string name)
   {
      this.instName = name;
   }

   public string Name
   {  get{ return this.instName; } }

   public virtual void Subscribe(IObservable<Location> provider)
   {
      if (provider != null) 
         unsubscriber = provider.Subscribe(this);
   }

   // <Snippet11>
   public virtual void OnCompleted()
   {
      Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
      this.Unsubscribe();
   }
   // </Snippet11>

   // <Snippet10>
   public virtual void OnError(Exception e)
   {
      Console.WriteLine("{0}: The location cannot be determined.", this.Name);
   }
   // </Snippet10>

   // <Snippet12>
   public virtual void OnNext(Location value)
   {
      Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, this.Name);
   }
   // </Snippet12>

   public virtual void Unsubscribe()
   {
      unsubscriber.Dispose();
   }
}
// </Snippet8>
