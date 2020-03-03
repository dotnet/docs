
// <snippet5>
using namespace System;
int main()
{
   char ch = '8';
   Console::WriteLine( Char::IsLetter( ch ) ); // False
   Console::WriteLine( Char::IsLetter(  "sample string", 7 ) ); // True
}

// </snippet5>
