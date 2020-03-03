
// <snippet6>
using namespace System;
int main()
{
   String^ str =  "newline:\n";
   Console::WriteLine( Char::IsLetterOrDigit( '8' ) ); // Output: "True"
   Console::WriteLine( Char::IsLetterOrDigit( str, 8 ) ); // Output: "False", because it's a newline
}

// </snippet6>
