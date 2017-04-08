#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

public ref class Test
{
// <Snippet1>
// Class-level declaration.
// Create a TraceSwitch.
private:
   static TraceSwitch^ generalSwitch = 
      gcnew TraceSwitch( "General", "Entire Application" );

public:
   static void MyErrorMethod( Object^ myObject )
   {
      #if defined(TRACE)
      // Write the message if the TraceSwitch level is set 
      // to Error or higher.
      Trace::WriteIf( generalSwitch->TraceError, myObject );
      
      // Write a second message if the TraceSwitch level is set
      // to Verbose.
      Trace::WriteLineIf( generalSwitch->TraceVerbose, 
         " is not a valid value for this method." );
      #endif
   }
   // </Snippet1>
};
