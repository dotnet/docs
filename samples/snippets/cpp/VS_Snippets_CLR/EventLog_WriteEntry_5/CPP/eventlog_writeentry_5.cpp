// System::Diagnostics::EventLog::WriteEntry(String, EventLogEntryType, Int32, Int16, Byte[])

/*
The following sample demonstrates the
'WriteEntry(String, EventLogEntryType, Int32, Int16, Byte->Item[])' method of
'EventLog' class. It writes an entry to a custom event log, S"MyLog".
It creates the source S"MySource" if the source does not already exist.
It creates an 'EventLog' Object* and calls 'WriteEntry' passing the
description, Log entry type, application specific identifier for the event,
application specific subcategory and  data to be associated with the entry.
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
      String^ myLogName = "myNewLog";
      if (  !EventLog::SourceExists( "MySource" ) )
      {
         EventLog::CreateEventSource( "MySource", myLogName );
         Console::WriteLine( "Creating EventSource" );
      }
      else
         myLogName = EventLog::LogNameFromSourceName( "MySource", "." );
      
      // Create an EventLog and assign source.
      EventLog^ myEventLog = gcnew EventLog;
      myEventLog->Source = "MySource";
      myEventLog->Log = myLogName;
      
      // Set the 'description' for the event.
      String^ myMessage = "This is my event.";
      EventLogEntryType myEventLogEntryType = EventLogEntryType::Warning;
      int myApplicatinEventId = 1100;
      short myApplicatinCategoryId = 1;
      
      // Set the 'data' for the event.
      array<Byte>^ myRawData = gcnew array<Byte>(4);
      for ( int i = 0; i < 4; i++ )
      {
         myRawData[ i ] = 1;
      }
      Console::WriteLine( "Writing to EventLog.. " );
      myEventLog->WriteEntry( myMessage, myEventLogEntryType, myApplicatinEventId, myApplicatinCategoryId, myRawData );
// </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception:{0}", e->Message );
   }
}
