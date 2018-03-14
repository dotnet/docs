

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   // Create the source, if it does not already exist.
   if (  !EventLog::SourceExists( "MySource" ) )
   {
      //An event log source should not be created and immediately used.
      //There is a latency time to enable the source, it should be created
      //prior to executing the application that uses the source.
      //Execute this sample a second time to use the new source.
      EventLog::CreateEventSource( "MySource", "MyNewLog", "myServer" );
      Console::WriteLine( "CreatingEventSource" );
      // The source is created.  Exit the application to allow it to be registered.
      return 0;
   }

   // Create an EventLog instance and assign its log name.
   EventLog^ myLog = gcnew EventLog( "myNewLog","myServer" );
   
   // Read the event log entries.
   System::Collections::IEnumerator^ myEnum = myLog->Entries->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EventLogEntry^ entry = safe_cast<EventLogEntry^>(myEnum->Current);
      Console::WriteLine( "\tEntry: {0}", entry->Message );
   }
}

// </Snippet1>
