
// <snippet1>
using namespace System;
int main()
{
   char ch2 = '2';
   String^ str = "Upper Case";
   Console::WriteLine( Char::GetUnicodeCategory( 'a' ).ToString() ); // Output: S"LowercaseLetter"
   Console::WriteLine( Char::GetUnicodeCategory( ch2 ).ToString() ); // Output: S"DecimalDigitNumber"
   Console::WriteLine( Char::GetUnicodeCategory( str, 6 ).ToString() ); // Output: S"UppercaseLetter"
}

// </snippet1>
