// System::Diagnostics::EventLogEntryCollection
// System::Diagnostics::EventLogEntryCollection::CopyTo(EventLogEntry->Item[],int)

/*
The following example demonstrates the EventLogEntryCollection class and the
CopyTo method of EventLogEntryCollection class.A new Source for eventlog 'MyNewLog'
is created.A new entry is created for 'MyNewLog'.The entries of EventLog are copied
to an Array.
*/

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Diagnostics;
int main()
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
      
      // Write an informational entry to the event log.
      myEventLog2->WriteEntry( "Successfully created a new Entry in the Log" );
      myEventLog2->Close();
      
      // Create a new EventLog Object*.
      EventLog^ myEventLog1 = gcnew EventLog;
      myEventLog1->Log = myLogName;
      
      // Obtain the Log Entries of S"MyNewLog".
      EventLogEntryCollection^ myEventLogEntryCollection = myEventLog1->Entries;
      myEventLog1->Close();
      Console::WriteLine( "The number of entries in 'MyNewLog' = {0}", myEventLogEntryCollection->Count );
      
      // Display the 'Message' property of EventLogEntry.
      for ( int i = 0; i < myEventLogEntryCollection->Count; i++ )
      {
         Console::WriteLine( "The Message of the EventLog is : {0}", myEventLogEntryCollection[ i ]->Message );
      }
      
      // Copy the EventLog entries to Array of type EventLogEntry.
      array<EventLogEntry^>^myEventLogEntryArray = gcnew array<EventLogEntry^>(myEventLogEntryCollection->Count);
      myEventLogEntryCollection->CopyTo( myEventLogEntryArray, 0 );
      IEnumerator^ myEnumerator = myEventLogEntryArray->GetEnumerator();
      while ( myEnumerator->MoveNext() )
      {
         EventLogEntry^ myEventLogEntry = safe_cast<EventLogEntry^>(myEnumerator->Current);
         Console::WriteLine( "The LocalTime the Event is generated is {0}", myEventLogEntry->TimeGenerated );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
