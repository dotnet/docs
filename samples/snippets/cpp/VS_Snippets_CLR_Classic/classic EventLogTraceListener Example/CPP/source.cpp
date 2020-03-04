#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

// <Snippet1>
int main()
{
   #if defined(TRACE)
   
   // Create a trace listener for the event log.
   EventLogTraceListener^ myTraceListener = 
      gcnew EventLogTraceListener( "myEventLogSource" );
   
   // Add the event log trace listener to the collection.
   Trace::Listeners->Add( myTraceListener );
   
   // Write output to the event log.
   Trace::WriteLine( "Test output" );
   
   #endif
}
// </Snippet1>
