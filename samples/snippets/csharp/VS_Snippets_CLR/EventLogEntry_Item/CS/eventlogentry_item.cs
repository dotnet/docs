// System.Diagnostics.EventLogEntryCollection.Count
// System.Diagnostics.EventLogEntryCollection.Item


/*
   The following example demonstrates 'Item','Count' properties of 
   EventLogEntryCollection class.A new Source for eventlog 'MyNewLog' is created.
   The program checks if a Event source exists.If the source already exists, it gets 
   the Log name associated with it otherwise, creates a new event source. 
   A new entry is created for 'MyNewLog'.Entries  of 'MyNewLog' are obtained and 
   the count and the messages are displayed.
   
 */

using System;
using System.Collections;
using System.Diagnostics;

class EventLogEntryCollection_Item
{
    public static void Main()
    {
        try
        {
            string myLogName = "MyNewLog";
            // Check if the source exists.
            if (!EventLog.SourceExists("MySource"))
            {
                // Create the source.
                // An event log source should not be created and immediately used.
                // There is a latency time to enable the source, it should be created
                // prior to executing the application that uses the source.
                // Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", myLogName);
                Console.WriteLine("Creating EventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }
            else
                // Get the EventLog associated if the source exists.
                myLogName = EventLog.LogNameFromSourceName("MySource", ".");

            // Create an EventLog instance and assign its source.
            EventLog myEventLog2 = new EventLog();
            myEventLog2.Source = "MySource";
            //Write an entry to the event log.
            myEventLog2.WriteEntry("Successfully created a new Entry in the Log. ");
            // <Snippet1>
            // <Snippet2>
            // Create a new EventLog object.
            EventLog myEventLog1 = new EventLog();
            myEventLog1.Log = myLogName;
            // Obtain the Log Entries of the Event Log
            EventLogEntryCollection myEventLogEntryCollection = myEventLog1.Entries;
            Console.WriteLine("The number of entries in 'MyNewLog' = " +
                                    myEventLogEntryCollection.Count);
            // Display the 'Message' property of EventLogEntry.
            for (int i = 0; i < myEventLogEntryCollection.Count; i++)
            {
                Console.WriteLine("The Message of the EventLog is :" +
                                        myEventLogEntryCollection[i].Message);
            }
            // </Snippet2>
            // </Snippet1>
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught!" + e.Message);
        }
    }
}