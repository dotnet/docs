#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

public ref class Class1
{
public:
   void Method()
   {
      // <Snippet1>
      // Create a ConsoletTraceListener and add it to the trace listeners.
      #if defined(TRACE)
      ConsoleTraceListener^ myWriter = gcnew ConsoleTraceListener( );
      Trace::Listeners->Add( myWriter );
      #endif
      // </Snippet1>
   }
};
