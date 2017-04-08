#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

int main( void )
{
   
   //<Snippet1>
   // Create a listener that outputs to the console screen 
   // and add it to the debug listeners.
   #if defined(DEBUG)
   TextWriterTraceListener^ myWriter = 
      gcnew TextWriterTraceListener( System::Console::Out );
   Debug::Listeners->Add( myWriter );
   #endif
   //</Snippet1>
}
