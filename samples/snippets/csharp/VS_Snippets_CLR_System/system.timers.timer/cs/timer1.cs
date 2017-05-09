// <Snippet1>
using System;
using System.Timers;

public class Example
{
    private static Timer aTimer;

    public static void Main()
    {
        // Create a timer and set a two second interval.
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 2000;

        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;

        // Have the timer fire repeated events (true is the default)
        aTimer.AutoReset = true;

        // Start the timer
        aTimer.Enabled = true;

        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();
    }

    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
    }
}
// The example displays output like the following: 
//       Press the Enter key to exit the program at any time... 
//       The Elapsed event was raised at 5/20/2015 8:48:58 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:00 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:02 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:04 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:06 PM 
// </Snippet1>
