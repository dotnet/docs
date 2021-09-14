// <Snippet1>
using System;

public class Destroyer
{
   public override string ToString() => GetType().Name;

   ~Destroyer() => Console.WriteLine($"The {ToString()} finalizer is executing.");
}
// </Snippet1>

class Program
{
   static void Main()
   {
        var destroyer = new Destroyer();
        destroyer = null;
        GC.GetTotalMemory(forceFullCollection: true);
        Console.WriteLine("Exiting...");
    }
}
