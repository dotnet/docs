
// The following code example demonstrates the effect of changing the 
// NumberDecimalSeparator property.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Gets a NumberFormatInfo associated with the en-US culture.
   CultureInfo^ MyCI = gcnew CultureInfo( "en-US",false );
   NumberFormatInfo^ nfi = MyCI->NumberFormat;
   
   // Displays a value with the default separator (S".").
   Int64 myInt = 123456789;
   Console::WriteLine( myInt.ToString( "N", nfi ) );
   
   // Displays the same value with a blank as the separator.
   nfi->NumberDecimalSeparator = " ";
   Console::WriteLine( myInt.ToString( "N", nfi ) );
}

/*
This code produces the following output.
123, 456, 789.00
123, 456, 789 00
*/
// </snippet1>
