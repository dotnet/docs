// System.Diagnostics.EventLogEntry.EntryType
// System.Diagnostics.EventLogEntry.Source

/*
The following example demonstrates the properties 'EntryType' and 'Source' 
of the class 'EventLogEntry'. 
A new instance of 'EventLog' class is created and is associated to existing 
System Log file of local machine. User selects the event type and the latest
entry in the log file of that type and it's source is displayed.
*/
// <Snippet1>
// <Snippet2>
using System;
using System.Diagnostics;
   class MyEventlogClass
   {
      public static void Main()
      {
         String myEventType=null;
         // Associate the instance of 'EventLog' with local System Log.
         EventLog myEventLog = new EventLog("System", ".");
         Console.WriteLine("1:Error");
         Console.WriteLine("2:Information");
         Console.WriteLine("3:Warning");
         Console.WriteLine("Select the Event Type");
         int myOption=Convert.ToInt32(Console.ReadLine());
         switch(myOption)
         {
            case 1:  myEventType="Error";
                     break;
            case 2:  myEventType="Information";
                     break;
            case 3:  myEventType="Warning";
                     break;
            default: break;
         }

            EventLogEntryCollection myLogEntryCollection=myEventLog.Entries;
            int myCount =myLogEntryCollection.Count;
            // Iterate through all 'EventLogEntry' instances in 'EventLog'.
            for(int i=myCount-1;i>0;i--)
            {
               EventLogEntry myLogEntry = myLogEntryCollection[i];
               // Select the entry having desired EventType.
               if(myLogEntry.EntryType.ToString().Equals(myEventType))
               {
                  // Display Source of the event.
                  Console.WriteLine(myLogEntry.Source
                     +" was the source of last event of type "
                     +myLogEntry.EntryType);
                  return;
               }
            }

         }
   }
// </Snippet2>
// </Snippet1>