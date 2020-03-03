#using <System.DLL>

// <Snippet1>
using namespace System;

void main()
{
   String^ str = "forty-two";
   Console::WriteLine( str->PadLeft( 15, L'.' ) ); 
   Console::WriteLine( str->PadLeft( 2, L'.' ) ); 
}
// The example displays the following output:
//       ......forty-two
//       forty-two
// </Snippet1>
