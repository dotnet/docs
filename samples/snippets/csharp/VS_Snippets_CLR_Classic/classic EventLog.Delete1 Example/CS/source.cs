// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;

class MySample
{

    public static void Main()
    {

        string logName;

        if (EventLog.SourceExists("MySource", "MyMachine"))
        {
            // Find the log associated with this source.    
            logName = EventLog.LogNameFromSourceName("MySource", "MyMachine");
            // Make sure the source is in the log we believe it to be in.
            if (logName != "MyLog")
                return;
            // Delete the source and the log.
            EventLog.DeleteEventSource("MySource", "MyMachine");
            EventLog.Delete(logName, "MyMachine");

            Console.WriteLine(logName + " deleted.");
        }
        else
        {
            // Create the event source to make next try successful.
            EventSourceCreationData mySourceData = new EventSourceCreationData("MySource", "MyLog");
            mySourceData.MachineName = "MyMachine";
            EventLog.CreateEventSource(mySourceData);
        }
    }
}

// </Snippet1>