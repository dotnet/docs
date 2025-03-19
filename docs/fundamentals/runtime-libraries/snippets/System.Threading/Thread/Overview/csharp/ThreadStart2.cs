// <Snippet2>
using System;
using System.Diagnostics;
using System.Threading;

public class Example3
{
   public static void Main()
   {
      var th = new Thread(ExecuteInForeground);
      th.Start(4500);
      Thread.Sleep(1000);
      Console.WriteLine("Main thread ({0}) exiting...",
                        Thread.CurrentThread.ManagedThreadId);
   }

   private static void ExecuteInForeground(Object obj)
   {
      int interval;
      try {
         interval = (int) obj;
      }
      catch (InvalidCastException) {
         interval = 5000;
      }
      var sw = Stopwatch.StartNew();
      Console.WriteLine("Thread {0}: {1}, Priority {2}",
                        Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.ThreadState,
                        Thread.CurrentThread.Priority);
      do {
         Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Elapsed {sw.ElapsedMilliseconds / 1000.0:N2} seconds");
         Thread.Sleep(500);
      } while (sw.ElapsedMilliseconds <= interval);
      sw.Stop();
   }
}
// The example displays output like the following:
//       Thread 3: Running, Priority Normal
//       Thread 3: Elapsed 0.00 seconds
//       Thread 3: Elapsed 0.52 seconds
//       Main thread (1) exiting...
//       Thread 3: Elapsed 1.03 seconds
//       Thread 3: Elapsed 1.55 seconds
//       Thread 3: Elapsed 2.06 seconds
//       Thread 3: Elapsed 2.58 seconds
//       Thread 3: Elapsed 3.09 seconds
//       Thread 3: Elapsed 3.61 seconds
//       Thread 3: Elapsed 4.12 seconds
// </Snippet2>
