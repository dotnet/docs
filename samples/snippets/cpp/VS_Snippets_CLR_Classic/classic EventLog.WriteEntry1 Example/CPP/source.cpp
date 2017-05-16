

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
      EventLog::CreateEventSource( "MySource", "myNewLog" );
      Console::WriteLine( "CreatingEventSource" );
   }

   
   // Write an informational entry to the event log.    
   EventLog::WriteEntry( "MySource", "Writing to event log." );
}

// </Snippet1>
