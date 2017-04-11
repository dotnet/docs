
// <snippet7>
using namespace System;
int main()
{
   char ch = 'a';
   Console::WriteLine( Char::IsLower( ch ) ); // Output: "True"
   Console::WriteLine( Char::IsLower(  "upperCase", 5 ) ); // Output: "False"
}

// </snippet7>
