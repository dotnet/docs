//<Snippet1>
using System;
using System.Management;

// This example shows asynchronous consumption of events.
// In this example you are listening for timer events.
// The first part of the example sets up the timer.
public class EventWatcherAsync 
{
    public EventWatcherAsync()
    {
        // Set up a timer to raise events every 1 second
        //=============================================
        ManagementClass timerClass = 
            new ManagementClass("__IntervalTimerInstruction");
        ManagementObject timer = timerClass.CreateInstance();
        timer["TimerId"] = "Timer1";
        timer["IntervalBetweenEvents"] = 1000;
        timer.Put();

        // Set up the event consumer
        //==========================
        // Create event query to receive timer events
        WqlEventQuery query = 
            new WqlEventQuery("__TimerEvent",
            "TimerId=\"Timer1\"");

        // Initialize an event watcher and 
        // subscribe to timer events 
        ManagementEventWatcher watcher = 
            new ManagementEventWatcher(query);

        // Set up a listener for events
        watcher.EventArrived += 
            new EventArrivedEventHandler(
            this.HandleEvent);

        // Start listening
        watcher.Start();

        // Do something in the meantime
        System.Threading.Thread.Sleep(10000);
      
        // Stop listening
        watcher.Stop();
        
    }


    private void HandleEvent(object sender,
        EventArrivedEventArgs e)   
    {
        Console.WriteLine("Event arrived !");
    }

    public static void Main(string[] args) 
    {
        // start the event watcher
        EventWatcherAsync eventWatcher = new
            EventWatcherAsync();
    }
}
//</Snippet1>