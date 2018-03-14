using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      ExecuteAsyncMethods().Wait();
   }

   private static async Task ExecuteAsyncMethods()
   {    
      Console.WriteLine("About to launch a task...");
      _ = Task.Run(() => { var iterations = 0;  
                           for (int ctr = 0; ctr < int.MaxValue; ctr++)
                              iterations++;
                           Console.WriteLine("Completed looping operation...");
                           throw new InvalidOperationException();
                         });
      await Task.Delay(5000);                        
      Console.WriteLine("Exiting after 5 second delay");
   }
}
// The example displays output like the following:
//       About to launch a task...
//       Completed looping operation...
//       Exiting after 5 second delay

