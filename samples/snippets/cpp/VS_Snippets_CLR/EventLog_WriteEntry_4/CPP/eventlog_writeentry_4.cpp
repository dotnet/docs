// System::Diagnostics::EventLog::WriteEntry(String,String,EventLogEntryType,Int32)

/*
The following sample demonstrates the
'WriteEntry(String,String,EventLogEntryType,Int32)' method of
'EventLog' class. It writes an entry to a custom event log, S"MyNewLog".
It creates the source S"MySource" if the source does not already exist.
*/

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

int main()
{
   try
   {
// <Snippet1>
      // Create the source, if it does not already exist.
      if (  !EventLog::SourceExists( "MySource" ) )
      {
         EventLog::CreateEventSource( "MySource", "myNewLog" );
         Console::WriteLine( "Creating EventSource" );
      }
      
      // Set the 'description' for the event.
      String^ myMessage = "This is my event.";
      EventLogEntryType myEventLogEntryType = EventLogEntryType::Warning;
      int myApplicationEventId = 100;
      
      // Write the entry in the event log.
      Console::WriteLine( "Writing to EventLog.. " );
      EventLog::WriteEntry( "MySource", myMessage,
         myEventLogEntryType, myApplicationEventId );
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception:{0}", e->Message );
   }
}
