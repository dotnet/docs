// System::Diagnostics::EventLogEntryCollection->Count
// System::Diagnostics::EventLogEntryCollection::Item

/*
The following example demonstrates 'Item','Count' properties of
EventLogEntryCollection class.A new Source for eventlog 'MyNewLog' is created.
The program checks if a Event source exists.If the source already exists, it gets
the Log name associated with it otherwise, creates a new event source.
A new entry is created for 'MyNewLog'.Entries  of 'MyNewLog' are obtained and
the count and the messages are displayed.

*/

#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Diagnostics;

void main()
{
   try
   {
      String^ myLogName = "MyNewLog";
      
      // Check if the source exists.
      if (  !EventLog::SourceExists( "MySource" ) )
      {
         
         //Create source.
         EventLog::CreateEventSource( "MySource", myLogName );
         Console::WriteLine( "Creating EventSource" );
      }
      else
         myLogName = EventLog::LogNameFromSourceName( "MySource", "." );
      
      // Get the EventLog associated if the source exists.
      // Create an EventLog instance and assign its source.
      EventLog^ myEventLog2 = gcnew EventLog;
      myEventLog2->Source = "MySource";
      
      //Write an entry to the event log.
      myEventLog2->WriteEntry( "Successfully created a new Entry in the Log. " );
      
      // <Snippet1>
      // <Snippet2>
      // Create a new EventLog object.
      EventLog^ myEventLog1 = gcnew EventLog;
      myEventLog1->Log = myLogName;
      
      // Obtain the Log Entries of the Event Log
      EventLogEntryCollection^ myEventLogEntryCollection = myEventLog1->Entries;
      Console::WriteLine( "The number of entries in 'MyNewLog' = {0}", myEventLogEntryCollection->Count );
      
      // Display the 'Message' property of EventLogEntry.
      for ( int i = 0; i < myEventLogEntryCollection->Count; i++ )
      {
         Console::WriteLine( "The Message of the EventLog is : {0}", myEventLogEntryCollection[ i ]->Message );
      }
      // </Snippet2>
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught! {0}", e->Message );
   }
}
