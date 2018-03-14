

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   
   // Write an informational entry to the event log.    
   EventLog::WriteEntry( "MySource", "Writing warning to event log.", EventLogEntryType::Warning );
}

// </Snippet1>
