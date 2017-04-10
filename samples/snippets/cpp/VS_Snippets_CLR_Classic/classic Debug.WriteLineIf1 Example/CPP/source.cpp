
#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

public ref class Test
{
   // <Snippet1>
   // Class-level declaration.
   // Create a TraceSwitch.
   static TraceSwitch^ generalSwitch = 
      gcnew TraceSwitch( "General","Entire Application" );

public:
   static void MyErrorMethod( Object^ myObject )
   {
      // Write the message if the TraceSwitch level is set to Error or higher.
      #if defined(DEBUG)
      Debug::WriteIf( generalSwitch->TraceError, "Invalid object. " );
      
      // Write a second message if the TraceSwitch level is set to Verbose.
      Debug::WriteLineIf( generalSwitch->TraceVerbose, myObject );
      #endif
   }
   // </Snippet1>
};
