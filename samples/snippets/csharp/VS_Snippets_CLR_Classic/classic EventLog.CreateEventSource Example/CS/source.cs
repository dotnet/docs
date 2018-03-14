// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    public static void Main(){
    
        // Create the source, if it does not already exist.
        if(!EventLog.SourceExists("MySource"))
        {
             //An event log source should not be created and immediately used.
             //There is a latency time to enable the source, it should be created
             //prior to executing the application that uses the source.
             //Execute this sample a second time to use the new source.
            EventLog.CreateEventSource("MySource", "MyNewLog");
            Console.WriteLine("CreatedEventSource");
            Console.WriteLine("Exiting, execute the application a second time to use the source.");
            // The source is created.  Exit the application to allow it to be registered.
            return;
        }
                
        // Create an EventLog instance and assign its source.
        EventLog myLog = new EventLog();
        myLog.Source = "MySource";
        
        // Write an informational entry to the event log.    
        myLog.WriteEntry("Writing to event log.");
        
    }
}
   
// </Snippet1>
