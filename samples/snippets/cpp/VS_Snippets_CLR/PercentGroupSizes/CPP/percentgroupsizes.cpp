
// The following code example demonstrates the effect of changing the PercentGroupSizes property.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Gets a NumberFormatInfo associated with the en-US culture.
   CultureInfo^ MyCI = gcnew CultureInfo( "en-US",false );
   NumberFormatInfo^ nfi = MyCI->NumberFormat;
   
   // Displays a value with the default separator (S".").
   Double myInt = 123456789012345.6789;
   Console::WriteLine( myInt.ToString( "P", nfi ) );
   
   // Displays the same value with different groupings.
   array<Int32>^mySizes1 = {2,3,4};
   array<Int32>^mySizes2 = {2,3,0};
   nfi->PercentGroupSizes = mySizes1;
   Console::WriteLine( myInt.ToString( "P", nfi ) );
   nfi->PercentGroupSizes = mySizes2;
   Console::WriteLine( myInt.ToString( "P", nfi ) );
}

/*
This code produces the following output.

12, 345, 678, 901, 234, 600.00 %
1234, 5678, 9012, 346, 00.00 %
123456789012, 346, 00.00 %
*/
// </snippet1>
