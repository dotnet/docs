// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    public static void Main(){
    
        // Create the source, if it does not already exist.
        if(!EventLog.SourceExists("MySource"))
        {
            // An event log source should not be created and immediately used.
            // There is a latency time to enable the source, it should be created
            // prior to executing the application that uses the source.
            // Execute this sample a second time to use the new source.
            EventLog.CreateEventSource("MySource", "myNewLog");
            Console.WriteLine("CreatingEventSource");
            Console.WriteLine("Exiting, execute the application a second time to use the source.");
            // The source is created.  Exit the application to allow it to be registered.
            return;
        }
                
      
        // Write an informational entry to the event log.    
        EventLog.WriteEntry("MySource", "Writing to event log.");
        
        
    }
}

// </Snippet1>
