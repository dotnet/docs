// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   String^ logName;
   if ( EventLog::SourceExists( "MySource", "MyMachine") )
   {
      
      // Find the log associated with this source.    
      logName = EventLog::LogNameFromSourceName( "MySource", "MyMachine" );
	  // Make sure the source is in the log we believe it to be in
      if (logName != "MyLog")
		  return -1;
      // Delete the source and the log.
      EventLog::DeleteEventSource( "MySource", "MyMachine" );
      EventLog::Delete( logName, "MyMachine" );
      Console::WriteLine( "{0} deleted.", logName );
   }
   else
        {
            // Create the event source to make next try successful.
			EventSourceCreationData^ mySourceData = gcnew EventSourceCreationData("MySource", "MyLog");
            mySourceData->MachineName = "MyMachine";
            EventLog::CreateEventSource(mySourceData);
        }
}

// </Snippet1>

