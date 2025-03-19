using System;

// <Snippet12>
// <Snippet9>
// <Snippet8>
public class TemperatureReporter : IObserver<Temperature>
// </Snippet8>
{
   private IDisposable unsubscriber;
   private bool first = true;
   private Temperature last;

   public virtual void Subscribe(IObservable<Temperature> provider)
   {
      unsubscriber = provider.Subscribe(this);
   }
   // </Snippet9>

   // <Snippet10>
   public virtual void Unsubscribe()
   {
      unsubscriber.Dispose();
   }
   // </Snippet10>

   // <Snippet11>
   public virtual void OnCompleted()
   {
      Console.WriteLine("Additional temperature data will not be transmitted.");
   }

   public virtual void OnError(Exception error)
   {
      // Do nothing.
   }

   public virtual void OnNext(Temperature value)
   {
      Console.WriteLine($"The temperature is {value.Degrees}°C at {value.Date:g}");
      if (first)
      {
         last = value;
         first = false;
      }
      else
      {
         Console.WriteLine("   Change: {0}° in {1:g}", value.Degrees - last.Degrees,
                                                       value.Date.ToUniversalTime() - last.Date.ToUniversalTime());
      }
   }
   // </Snippet11>
}
// </Snippet12>
