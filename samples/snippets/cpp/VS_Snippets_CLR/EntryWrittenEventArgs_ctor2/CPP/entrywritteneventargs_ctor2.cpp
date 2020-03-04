// System::Diagnostics::EntryWrittenEventArgs::ctor(EventLogEntry)
// System::Diagnostics::EntryWrittenEventArgs::Entry

/* 
The following example demonstrates the 'Entry' property and EntryWrittenEventArgs (EventLogEntry)
constructor of the  'EntryWrittenEventArgs' class. It creates a custom 'EventLog' and writes an
entry into it. Then creates an 'EntryWrittenEventArgs' Object* using the first entry in the custom
eventlog.This Object* is used to notify a message 
*/

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

// <Snippet2>
void MyOnEntry( Object^ source, EntryWrittenEventArgs^ e )
{
   EventLogEntry^ myEventLogEntry = e->Entry;
   if ( myEventLogEntry )
   {
      Console::WriteLine( "Current message entry is: '{0}'", myEventLogEntry->Message );
   }
   else
   {
      Console::WriteLine( "The current entry is null" );
   }
}
// </Snippet2>

int main()
{
   try
   {
      EventLog^ myNewLog = gcnew EventLog;
      myNewLog->Log = "MyNewLog";
      myNewLog->Source = "MySource";
      
      // Create the source if it does not exist already.
      if (  !EventLog::SourceExists( "MySource" ) )
      {
         EventLog::CreateEventSource( "MySource", "MyNewLog" );
         Console::WriteLine( "CreatingEventSource" );
      }
      
      // Write an entry to the EventLog.
      myNewLog->WriteEntry( "The Latest entry in the Event Log" );
      int myEntries = myNewLog->Entries->Count;
      EventLogEntry^ entry = myNewLog->Entries[ myEntries - 1 ];
      EntryWrittenEventArgs^ myEntryEventArgs = gcnew EntryWrittenEventArgs( entry );
      MyOnEntry( myNewLog, myEntryEventArgs );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Raised {0}", e->Message );
   }
}
// </Snippet1>
