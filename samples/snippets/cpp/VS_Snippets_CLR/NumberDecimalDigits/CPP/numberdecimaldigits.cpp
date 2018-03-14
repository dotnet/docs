
// The following code example demonstrates the effect of changing the NumberDecimalDigits property.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Gets a NumberFormatInfo associated with the en-US culture.
   CultureInfo^ MyCI = gcnew CultureInfo( "en-US",false );
   NumberFormatInfo^ nfi = MyCI->NumberFormat;
   
   // Displays a negative value with the default number of decimal digits (2).
   Int64 myInt = -1234;
   Console::WriteLine( myInt.ToString( "N", nfi ) );
   
   // Displays the same value with four decimal digits.
   nfi->NumberDecimalDigits = 4;
   Console::WriteLine( myInt.ToString( "N", nfi ) );
}

/* 
This code produces the following output.
-1, 234.00
-1, 234.0000
*/
// </snippet1>
