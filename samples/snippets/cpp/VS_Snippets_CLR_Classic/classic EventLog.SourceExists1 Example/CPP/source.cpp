

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   
   // Create the source, if it does not already exist.
   if (  !EventLog::SourceExists( "MySource", "MyServer" ) )
   {
      EventLog::CreateEventSource( "MySource", "MyNewLog", "MyServer" );
      Console::WriteLine( "CreatingEventSource" );
   }

   
   // Create an EventLog instance and assign its source.
   EventLog^ myLog = gcnew EventLog;
   myLog->Source = "MySource";
   
   // Write an informational entry to the event log.    
   myLog->WriteEntry( "Writing to event log." );
   Console::WriteLine( "Message written to event log." );
}

// </Snippet1>
