// System::Diagnostics::EventLog::WriteEntry(String, String, EventLogEntryType, Int32, Int16)
// System::Diagnostics::EventLog::WriteEntry(String, String, EventLogEntryType, Int32, Int16, Byte->Item[])
// System::Diagnostics::EventLog::EventLog.WriteEntry(String, EventLogEntryType, Int32, Int16)

/* The following example demonstrates the method
'WriteEntry(String, String, EventLogEntryType, Int32, Int16)',
'WriteEntry(String, String, EventLogEntryType, Int32, Int16, Byte->Item[]) '
and 'WriteEntry(String, EventLogEntryType, Int32, Int16)' of class
'EventLog'.The following example writes the information to an event log.
*/

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

int main()
{
   // <Snippet1>
   int myEventID = 20;
   short myCategory = 10;

   // Write an informational entry to the event log.
   Console::WriteLine( "Write from first source " );
   EventLog::WriteEntry( "FirstSource", "Writing warning to event log.",
      EventLogEntryType::Information, myEventID, myCategory );
   // </Snippet1>

   // <Snippet2>
   //Create a byte array for binary data to associate with the entry.
   array<Byte>^myByte = gcnew array<Byte>(10);
   //Populate the byte array with simulated data.
   for ( int i = 0; i < 10; i++ )
   {
      myByte[ i ] = (Byte)(i % 2);
   }
   //Write an entry to the event log that includes associated binary data.
   Console::WriteLine( "Write from second source " );
   EventLog::WriteEntry( "SecondSource", "Writing warning to event log.",
      EventLogEntryType::Error, myEventID, myCategory, myByte );
   // </Snippet2>

   // <Snippet3>
   // Create an EventLog instance and assign its source.
   EventLog^ myLog = gcnew EventLog;
   myLog->Source = "ThirdSource";
   
   // Write an informational entry to the event log.
   Console::WriteLine( "Write from third source " );
   myLog->WriteEntry( "Writing warning to event log.",
      EventLogEntryType::Warning, myEventID, myCategory );
   // </Snippet3>
}
