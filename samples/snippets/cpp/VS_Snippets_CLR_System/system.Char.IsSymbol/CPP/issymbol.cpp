
// <snippet12>
using namespace System;
int main()
{
   String^ str =  "non-symbolic characters";
   Console::WriteLine( Char::IsSymbol( '+' ) ); // Output: "True"
   Console::WriteLine( Char::IsSymbol( str, 8 ) ); // Output: "False"
}

// </snippet12>
