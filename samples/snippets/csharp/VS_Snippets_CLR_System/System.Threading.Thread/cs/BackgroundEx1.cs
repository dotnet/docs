﻿// <Snippet3>
using System;
using System.Diagnostics;
using System.Threading;

public class Example
{
   public static void Main()
   {
      var th = new Thread(ExecuteInForeground);
      th.IsBackground = true;
      th.Start();
      Thread.Sleep(1000);
      Console.WriteLine("Main thread ({0}) exiting...",
                        Thread.CurrentThread.ManagedThreadId);
   }

   private static void ExecuteInForeground()
   {
      DateTime start = DateTime.Now;
      var sw = Stopwatch.StartNew();
      Console.WriteLine("Thread {0}: {1}, Priority {2}",
                        Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.ThreadState,
                        Thread.CurrentThread.Priority);
      do {
         Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                           Thread.CurrentThread.ManagedThreadId,
                           sw.ElapsedMilliseconds / 1000.0);
         Thread.Sleep(500);
      } while (sw.ElapsedMilliseconds <= 5000);
      sw.Stop();
   }
}
// The example displays output like the following:
//       Thread 3: Background, Priority Normal
//       Thread 3: Elapsed 0.00 seconds
//       Thread 3: Elapsed 0.51 seconds
//       Main thread (1) exiting...
// </Snippet3>
