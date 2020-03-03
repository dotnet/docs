
// <snippet3>
using namespace System;
int main()
{
   String^ str =  "sample string";
   Console::WriteLine( Char::IsControl( '\t' ) ); // Output: "True"
   Console::WriteLine( Char::IsControl( str, 7 ) ); // Output: "False"
}

// </snippet3>
