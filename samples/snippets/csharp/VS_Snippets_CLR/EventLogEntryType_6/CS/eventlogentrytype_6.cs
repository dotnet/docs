// System.Diagnostics.EventLogEntryType
// System.Diagnostics.EventLogEntryType.Error
// System.Diagnostics.EventLogEntryType.Warning
// System.Diagnostics.EventLogEntryType.Information
// System.Diagnostics.EventLogEntryType.FailureAudit
// System.Diagnostics.EventLogEntryType.SuccessAudit

/* The following program demonstrates 'Error', 'Warning', 
   'Information', 'FailureAudit' and 'SuccessAudit' members of 
   'EventLogEntryType' enumerator. It creates new source with a 
   specified event log, new ID, EventLogEntryType and message,
   if does not exist.
*/

// <Snippet1>
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

class MyEventLogEntryType
{
    public static void Main()
    {
        try
        {
            EventLog myEventLog;
            string mySource = null;
            string myLog = null;
            string myType = null;
            string myMessage = "A new event is created.";
            string myEventID = null;
            int myIntLog = 0;
            int myID = 0;
            Console.Write("Enter source name for new event (eg: Print ): ");
            mySource = Console.ReadLine();
            Console.Write("Enter log name in which to write an event( eg: System ): ");
            myLog = Console.ReadLine();
            // Check whether source exist in event log.
            if (false == EventLog.SourceExists(mySource))
            {
                // Create a new source in a specified log on a system.
                // An event log source should not be created and immediately used.
                // There is a latency time to enable the source, it should be created
                // prior to executing the application that uses the source.
                // Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(mySource, myLog);
                Console.WriteLine("Creating the event source, press the Enter key to exit the application, \n" +
                    "then run the applicaton again to use the new event source.");
                Console.Read();
            }
            Console.WriteLine("");
            Console.WriteLine("     Select type of event to write:");
            Console.WriteLine("       1.     Error ");
            Console.WriteLine("       2.     Warning");
            Console.WriteLine("       3.     Information");
            Console.WriteLine("       4.     FailureAudit");
            Console.WriteLine("       5.     SuccessAudit");
            Console.Write("Enter the choice(eg. 1): ");
            myType = Console.ReadLine();
            myIntLog = Convert.ToInt32(myType);
            Console.Write("Enter ID with which to write an event( eg: 0-65535 ): ");
            myEventID = Console.ReadLine();
            myID = Convert.ToInt32(myEventID);
            // <Snippet2>

            // Create an event log instance.
            myEventLog = new EventLog(myLog);
            // Initialize source property of obtained instance.
            myEventLog.Source = mySource;
            switch (myIntLog)
            {
                case 1:
                    // Write an 'Error' entry in specified log of event log.
                    myEventLog.WriteEntry(myMessage, EventLogEntryType.Error, myID);
                    break;
                case 2:
                    // Write a 'Warning' entry in specified log of event log.
                    myEventLog.WriteEntry(myMessage, EventLogEntryType.Warning, myID);
                    break;
                case 3:
                    // Write an 'Information' entry in specified log of event log.
                    myEventLog.WriteEntry(myMessage, EventLogEntryType.Information, myID);
                    break;
                case 4:
                    // Write a 'FailureAudit' entry in specified log of event log.
                    myEventLog.WriteEntry(myMessage, EventLogEntryType.FailureAudit, myID);
                    break;
                case 5:
                    // Write a 'SuccessAudit' entry in specified log of event log.
                    myEventLog.WriteEntry(myMessage, EventLogEntryType.SuccessAudit, myID);
                    break;
                default:
                    Console.WriteLine("Error: Failed to create an event in event log.");
                    break;
            }
            Console.WriteLine("A new event in log '{0}' with ID '{1}' "
               + "is successfully written into event log.",
               myEventLog.Log, myID);
            // </Snippet2>
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
// </Snippet1>
