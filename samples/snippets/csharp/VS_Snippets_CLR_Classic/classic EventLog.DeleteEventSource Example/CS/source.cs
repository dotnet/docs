// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;

class MySample
{

    public static void Main()
    {

        string logName;

        if (EventLog.SourceExists("MySource"))
        {
            // Find the log associated with this source.    
            logName = EventLog.LogNameFromSourceName("MySource", ".");
            // Make sure the source is in the log we believe it to be in.
            if (logName != "MyLog")
                return;
            // Delete the source and the log.
            EventLog.DeleteEventSource("MySource");
            EventLog.Delete(logName);

            Console.WriteLine(logName + " deleted.");
        }
        else
        {
            // Create the event source to make next try successful.
            EventLog.CreateEventSource("MySource", "MyLog");
        }
    }
}

// </Snippet1>