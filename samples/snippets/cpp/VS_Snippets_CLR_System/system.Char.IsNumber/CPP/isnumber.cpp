
// <snippet8>
using namespace System;
int main()
{
   String^ str =  "non-numeric";
   Console::WriteLine( Char::IsNumber( '8' ) ); // Output: "True"
   Console::WriteLine( Char::IsNumber( str, 3 ) ); // Output: "False"
}

// </snippet8>
