#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

int main( void )
{
   
   // <Snippet1>
   // Create a local value.
   int index;
   
   // Perform some action that sets the local value.
   index = -40;
   
   // Test that the local value is valid. 
   #if defined(DEBUG)
   Debug::Assert( index > -1 );
   #endif
   // </Snippet1>
   
   return 0;
}
