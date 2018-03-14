
// <snippet14>
using namespace System;
int main()
{
   String^ str =  "black matter";
   Console::WriteLine( Char::IsWhiteSpace( 'A' ) ); // Output: "False"
   Console::WriteLine( Char::IsWhiteSpace( str, 5 ) ); // Output: "True"
}

// </snippet14>
