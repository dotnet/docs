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
   static void MyErrorMethod()
   {
      // Write the message if the TraceSwitch level is set
      // to Error or higher.
      if ( generalSwitch->TraceError )
      {
         Trace::Write( "My error message. " );
      }
      
      // Write a second message if the TraceSwitch level is set
      // to Verbose.
      if ( generalSwitch->TraceVerbose )
      {
          Trace::WriteLine( "My second error message." );
      }
   }
// </Snippet1>
};
