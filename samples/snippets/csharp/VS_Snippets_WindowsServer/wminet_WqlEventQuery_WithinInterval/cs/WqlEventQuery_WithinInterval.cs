//<Snippet1>
using System;
using System.Management;

// This example shows synchronous consumption of events. 
// The client is blocked while waiting for events. 

public class EventWatcherPolling 
{
    public static int Main(string[] args) 
    {
        // Create event query to be notified within 1 second of 
        // a new process being created
        WqlEventQuery query = 
            new WqlEventQuery("__InstanceCreationEvent", 
            new TimeSpan(0,0,1), 
            "TargetInstance isa \"Win32_Process\"");

        // Initialize an event watcher and subscribe to events 
        // that match this query
        ManagementEventWatcher watcher =
            new ManagementEventWatcher(query);
        // times out watcher.WaitForNextEvent in 5 seconds
        watcher.Options.Timeout = new TimeSpan(0,0,5);
      
        // Block until the next event occurs 
        // Note: this can be done in a loop if waiting for 
        //        more than one occurrence
        Console.WriteLine(
            "Open an application (notepad.exe) to trigger an event.");
        ManagementBaseObject e = watcher.WaitForNextEvent();

        //Display information from the event
        Console.WriteLine(
            "Process {0} has been created, path is: {1}", 
            ((ManagementBaseObject)e
            ["TargetInstance"])["Name"],
            ((ManagementBaseObject)e
            ["TargetInstance"])["ExecutablePath"]);

        //Cancel the subscription
        watcher.Stop();
        return 0;
    }
}
//</Snippet1>