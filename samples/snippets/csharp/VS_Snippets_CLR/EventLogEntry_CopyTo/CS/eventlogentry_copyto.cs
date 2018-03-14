// System.Diagnostics.EventLogEntryCollection
// System.Diagnostics.EventLogEntryCollection.CopyTo(EventLogEntry[],int)

/*
   The following example demonstrates the EventLogEntryCollection class and the 
   CopyTo method of EventLogEntryCollection class.A new Source for eventlog 'MyNewLog'
   is created.A new entry is created for 'MyNewLog'.The entries of EventLog are copied
   to an Array.
 */

// <Snippet1>
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
            // Write an informational entry to the event log.
            myEventLog2.WriteEntry("Successfully created a new Entry in the Log");
            myEventLog2.Close();
            // Create a new EventLog object.
            EventLog myEventLog1 = new EventLog();
            myEventLog1.Log = myLogName;

            // Obtain the Log Entries of "MyNewLog".
            EventLogEntryCollection myEventLogEntryCollection =
               myEventLog1.Entries;
            myEventLog1.Close();
            Console.WriteLine("The number of entries in 'MyNewLog' = "
               + myEventLogEntryCollection.Count);

            // Display the 'Message' property of EventLogEntry.
            for (int i = 0; i < myEventLogEntryCollection.Count; i++)
            {
                Console.WriteLine("The Message of the EventLog is :"
                   + myEventLogEntryCollection[i].Message);
            }
            // <Snippet2>

            // Copy the EventLog entries to Array of type EventLogEntry.
            EventLogEntry[] myEventLogEntryArray =
               new EventLogEntry[myEventLogEntryCollection.Count];
            myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0);
            IEnumerator myEnumerator = myEventLogEntryArray.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                EventLogEntry myEventLogEntry = (EventLogEntry)myEnumerator.Current;
                Console.WriteLine("The LocalTime the Event is generated is "
                   + myEventLogEntry.TimeGenerated);
            }
            // </Snippet2>
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception:{0}", e.Message);
        }
    }
}
// </Snippet1>
