// <Snippet1>
using System;

public class Destroyer
{
   public override string ToString() => GetType().Name;
   
   ~Destroyer() => Console.WriteLine($"The {ToString()} destructor is executing.");
}
// </Snippet1>

class Program
{
   static void Main()
   {
      var destroyer = new Destroyer();
      destroyer = null;
      GC.Collect();
      Console.WriteLine("Exiting...");
   }
}
