

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
      EventLog::CreateEventSource( "MySource", "MyNewLog");
      Console::WriteLine( "CreatingEventSource" );
      // The source is created.  Exit the application to allow it to be registered.
      return 0;
   }
   
   // Create an EventLog instance and assign its source.
   EventLog^ myLog = gcnew EventLog( "myNewLog",".","MySource" );
   
   // Write an entry to the log.        
   myLog->WriteEntry( String::Format( "Writing to event log on {0}", myLog->MachineName ) );
}

// </Snippet1>
