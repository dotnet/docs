// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    public static void Main(){
    
                
        // Create an EventLog instance and assign its source.
        EventLog myLog = new EventLog("MyNewLog");
        myLog.Source = "MyNewLogSource";
        
        // Write an informational entry to the event log.    
        myLog.WriteEntry("Writing warning to event log.", EventLogEntryType.Warning);
        
    }
}
      
// </Snippet1>
