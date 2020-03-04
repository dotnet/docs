// <Snippet1>
// Specify /DTRACE when compiling.

#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

int main()
{
   #if defined(TRACE)
   Trace::Listeners->Add( gcnew TextWriterTraceListener( Console::Out ) );
   Trace::AutoFlush = true;
   Trace::Indent();
   Trace::WriteLine( "Entering Main" );
   #endif
   Console::WriteLine( "Hello World." );
   #if defined(TRACE)
   Trace::WriteLine( "Exiting Main" );
   Trace::Unindent();
   #endif
   return 0;
}
// </Snippet1>
