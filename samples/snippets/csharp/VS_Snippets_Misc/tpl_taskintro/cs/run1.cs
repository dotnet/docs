// <Snippet2>
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Run;

public class Example
{
   public static void Main()
   {
      Thread.CurrentThread.Name = "Main";

      // Define and run the task.
      Task taskA = Task.Run( () => Console.WriteLine("Hello from taskA."));

      // Output a message from the calling thread.
      Console.WriteLine($"Hello from thread '{Thread.CurrentThread.Name}'.");
      taskA.Wait();
   }
}
// The example displays output as follows:
//       Hello from thread 'Main'.
//       Hello from taskA.
// or
//       Hello from taskA.
//       Hello from thread 'Main'.
// </Snippet2>
