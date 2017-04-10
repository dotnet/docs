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
   static void MyErrorMethod( Object^ myObject, String^ category )
   {
      #if defined(TRACE)
      // Write the message if the TraceSwitch level is set to Verbose.
      if ( generalSwitch->TraceVerbose )
      {
         Trace::Write( String::Concat( myObject, 
            " is not a valid object for category: " ), category );
      }
      
      // Write a second message if the TraceSwitch level is set to
      // Error or higher.
      if ( generalSwitch->TraceError )
      {
         Trace::WriteLine( " Please use a different category." );
      }
      #endif
   }
// </Snippet1>
};
