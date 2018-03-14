// What is the resolution of the system clock?

// <Snippet1>
using System;
using System.IO;
using System.Collections.Generic;
using System.Timers;

public class Example
{
   private static Timer aTimer;
   private static List<String> eventlog;
   private static int nEventsFired = 0;
   private static DateTime previousTime;
       
   public static void Main()
   {
        eventlog = new List<String>();
        
        StreamWriter sr = new StreamWriter(@".\Interval.txt");
        // Create a timer with a five millisecond interval.
        aTimer = new Timer(5);
        aTimer.Elapsed += OnTimedEvent;
        // Hook up the Elapsed event for the timer. 
        aTimer.AutoReset = true;
        sr.WriteLine("The timer should fire every {0} milliseconds.", 
                     aTimer.Interval);
        aTimer.Enabled = true;

        
        Console.WriteLine("Press the Enter key to exit the program... ");
        Console.ReadLine();
        foreach (var item in eventlog)
           sr.WriteLine(item);
        sr.Close();
        Console.WriteLine("Terminating the application...");
   }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        eventlog.Add(String.Format("Elapsed event at {0:HH':'mm':'ss.ffffff} ({1})", 
                                   e.SignalTime, 
                                   nEventsFired++ == 0 ? 
                                      0.0 : (e.SignalTime - previousTime).TotalMilliseconds));
        previousTime = e.SignalTime;
        if (nEventsFired == 20) {
           Console.WriteLine("No more events will fire...");
           aTimer.Enabled = false;
        }
    }
}
// The example writes output like the following to a file:
//       The timer should fire every 5 milliseconds.
//       Elapsed event at 08:42:49.370344 (0)
//       Elapsed event at 08:42:49.385345 (15.0015)
//       Elapsed event at 08:42:49.400347 (15.0015)
//       Elapsed event at 08:42:49.415348 (15.0015)
//       Elapsed event at 08:42:49.430350 (15.0015)
//       Elapsed event at 08:42:49.445351 (15.0015)
//       Elapsed event at 08:42:49.465353 (20.002)
//       Elapsed event at 08:42:49.480355 (15.0015)
//       Elapsed event at 08:42:49.495356 (15.0015)
//       Elapsed event at 08:42:49.510358 (15.0015)
//       Elapsed event at 08:42:49.525359 (15.0015)
//       Elapsed event at 08:42:49.540361 (15.0015)
//       Elapsed event at 08:42:49.555362 (15.0015)
//       Elapsed event at 08:42:49.570364 (15.0015)
//       Elapsed event at 08:42:49.585365 (15.0015)
//       Elapsed event at 08:42:49.605367 (20.002)
//       Elapsed event at 08:42:49.620369 (15.0015)
//       Elapsed event at 08:42:49.635370 (15.0015)
//       Elapsed event at 08:42:49.650372 (15.0015)
//       Elapsed event at 08:42:49.665373 (15.0015)
// </Snippet1>

