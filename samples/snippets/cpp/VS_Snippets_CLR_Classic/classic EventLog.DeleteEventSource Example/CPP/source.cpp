

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   String^ logName;
   if ( EventLog::SourceExists( "MySource" ) )
   {
      
      // Find the log associated with this source.    
      logName = EventLog::LogNameFromSourceName( "MySource", "." );
	  // Make sure the source is in the log we believe it to be in
      if (logName != "MyLog")
		  return -1;
      // Delete the source and the log.
      EventLog::DeleteEventSource( "MySource" );
      EventLog::Delete( logName );
      Console::WriteLine( "{0} deleted.", logName );
   }
   else
        {
            // Create the event source to make next try successful.
            EventLog::CreateEventSource("MySource", "MyLog");
        }
}

// </Snippet1>

