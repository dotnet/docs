// System.Diagnostics.EventLog.WriteEntry(String,String,EventLogEntryType,Int32)

/*
 The following sample demonstrates the
 'WriteEntry(String,String,EventLogEntryType,Int32)' method of
 'EventLog' class. It writes an entry to a custom event log, "MyNewLog".
 It creates the source "MySource" if the source does not already exist.
*/

using System;
using System.Diagnostics;
class EventLog_WriteEntry_4
{
   public static void Main()
   {
      try
      {
// <Snippet1>
         // Create the source, if it does not already exist.
         if(!EventLog.SourceExists("MySource"))
         {
            // An event log source should not be created and immediately used.
            // There is a latency time to enable the source, it should be created
            // prior to executing the application that uses the source.
            // Execute this sample a second time to use the new source.
            EventLog.CreateEventSource("MySource", "myNewLog");
            Console.WriteLine("Creating EventSource");
            Console.WriteLine("Exiting, execute the application a second time to use the source.");
            // The source is created.  Exit the application to allow it to be registered.
            return;
         }

         // Set the 'description' for the event.
         string myMessage = "This is my event.";
         EventLogEntryType myEventLogEntryType = EventLogEntryType.Warning;
         int myApplicationEventId = 100;

         // Write the entry in the event log.
         Console.WriteLine("Writing to EventLog.. ");
         EventLog.WriteEntry("MySource",myMessage,
            myEventLogEntryType, myApplicationEventId);
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception:{0}",e.Message);
      }
   }
}