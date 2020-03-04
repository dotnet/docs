
// The following code example demonstrates the effect of changing the 
// PercentDecimalSeparator property.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Gets a NumberFormatInfo associated with the en-US culture.
   CultureInfo^ MyCI = gcnew CultureInfo( "en-US",false );
   NumberFormatInfo^ nfi = MyCI->NumberFormat;
   
   // Displays a value with the default separator (S".").
   Double myInt = 0.1234;
   Console::WriteLine( myInt.ToString( "P", nfi ) );
   
   // Displays the same value with a blank as the separator.
   nfi->PercentDecimalSeparator = " ";
   Console::WriteLine( myInt.ToString( "P", nfi ) );
}

/*
This code produces the following output.
12.34 %
12 34 %
*/
// </snippet1>
