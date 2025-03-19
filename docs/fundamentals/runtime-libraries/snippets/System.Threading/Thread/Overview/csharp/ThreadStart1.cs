// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;

public class Example2
{
   public static void Main()
   {
      var th = new Thread(ExecuteInForeground);
      th.Start();
      Thread.Sleep(1000);
      Console.WriteLine("Main thread ({0}) exiting...",
                        Thread.CurrentThread.ManagedThreadId);
   }

   private static void ExecuteInForeground()
   {
      var sw = Stopwatch.StartNew();
      Console.WriteLine("Thread {0}: {1}, Priority {2}",
                        Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.ThreadState,
                        Thread.CurrentThread.Priority);
      do {
         Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Elapsed {sw.ElapsedMilliseconds / 1000.0:N2} seconds");
         Thread.Sleep(500);
      } while (sw.ElapsedMilliseconds <= 5000);
      sw.Stop();
   }
}
// The example displays output like the following:
//       Thread 3: Running, Priority Normal
//       Thread 3: Elapsed 0.00 seconds
//       Thread 3: Elapsed 0.51 seconds
//       Main thread (1) exiting...
//       Thread 3: Elapsed 1.02 seconds
//       Thread 3: Elapsed 1.53 seconds
//       Thread 3: Elapsed 2.05 seconds
//       Thread 3: Elapsed 2.55 seconds
//       Thread 3: Elapsed 3.07 seconds
//       Thread 3: Elapsed 3.57 seconds
//       Thread 3: Elapsed 4.07 seconds
//       Thread 3: Elapsed 4.58 seconds
// </Snippet1>
