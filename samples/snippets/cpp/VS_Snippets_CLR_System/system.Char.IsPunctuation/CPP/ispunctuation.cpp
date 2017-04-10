
// <snippet9>
using namespace System;
int main()
{
   char ch = '.';
   Console::WriteLine( Char::IsPunctuation( ch ) ); // Output: "True"
   Console::WriteLine( Char::IsPunctuation(  "no punctuation", 3 ) ); // Output: "False"
}

// </snippet9>
