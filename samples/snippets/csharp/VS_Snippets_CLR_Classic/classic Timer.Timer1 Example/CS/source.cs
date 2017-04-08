// <Snippet1>
using System;
using System.Timers;

public class Example
{
    private static Timer aTimer;

    public static void Main()
    {
        // Create a timer with a 1.5 second interval.
        double interval = 1500.0;
        aTimer = new System.Timers.Timer(interval);
        
        // Hook up the event handler for the Elapsed event.
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        // Only raise the event the first time Interval elapses.
        aTimer.AutoReset = false;
        aTimer.Enabled = true;
        
        // Ensure the event fires before the exit message appears.
        System.Threading.Thread.Sleep((int) interval * 2);
        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();
    }
 
    // Handle the Elapsed event.
    private static void OnTimedEvent(object source, ElapsedEventArgs e) 
    {
        Console.WriteLine("Hello World!");
    }
}
// This example displays the following output:
//       Hello World!
//       Press the Enter key to exit the program.
// </Snippet1>
