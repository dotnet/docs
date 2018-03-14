// <Snippet1>
// Specify /DDEBUG when compiling.

#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

int main( void )
{
   #if defined(DEBUG)
   Debug::Listeners->Add( gcnew TextWriterTraceListener( Console::Out ) );
   Debug::AutoFlush = true;
   Debug::Indent();
   Debug::WriteLine( "Entering Main" );
   #endif
   Console::WriteLine( "Hello World." );
   #if defined(DEBUG)
   Debug::WriteLine( "Exiting Main" );
   Debug::Unindent();
   #endif
   return 0;
}
// </Snippet1>

