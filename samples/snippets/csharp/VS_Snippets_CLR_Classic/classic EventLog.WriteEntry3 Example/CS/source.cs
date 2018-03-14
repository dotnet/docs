// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    public static void Main(){
                    
      
        // Write an informational entry to the event log.    
        EventLog.WriteEntry("MySource", 
			"Writing warning to event log.", 
			EventLogEntryType.Warning);
        
    }
}
      
// </Snippet1>
