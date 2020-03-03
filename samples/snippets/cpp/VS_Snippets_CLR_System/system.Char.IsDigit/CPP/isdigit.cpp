
// <snippet4>
using namespace System;
int main()
{
   char ch = '8';
   Console::WriteLine( Char::IsDigit( ch ) ); // Output: "True"
   Console::WriteLine( Char::IsDigit(  "sample string", 7 ) ); // Output: "False"
}

// </snippet4>
