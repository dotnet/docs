#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

int main( void )
{
   //<Snippet1>
   #if defined(DEBUG)
   Debug::WriteLine( "List of errors:" );
   Debug::Indent();
   Debug::WriteLine( "Error 1: File not found" );
   Debug::WriteLine( "Error 2: Directory not found" );
   Debug::Unindent();
   Debug::WriteLine( "End of list of errors" );
   #endif
   //</Snippet1>
}
