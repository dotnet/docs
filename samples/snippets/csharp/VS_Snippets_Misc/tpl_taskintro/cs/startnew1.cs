// <Snippet3>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Thread.CurrentThread.Name = "Main";

      // Better: Create and start the task in one operation. 
      Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA."));
      
      // Output a message from the calling thread.
      Console.WriteLine("Hello from thread '{0}'.", 
                        Thread.CurrentThread.Name);

      taskA.Wait();                  
   }
}
// The example displays output like the following:
//       Hello from thread 'Main'.
//       Hello from taskA.
// </Snippet3>
