// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   
   // Create an EventLog instance and assign its source.
   EventLog^ myLog = gcnew EventLog("MyNewLog");
   myLog->Source = "MyNewLogSource";
   
   // Write an informational entry to the event log.    
   myLog->WriteEntry( "Writing warning to event log.", EventLogEntryType::Warning );
}

// </Snippet1>
