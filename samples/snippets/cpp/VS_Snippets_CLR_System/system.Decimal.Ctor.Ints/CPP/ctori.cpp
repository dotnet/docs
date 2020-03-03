
//<Snippet1>
// Example of the Decimal( int ) constructor.
using namespace System;

// Create a Decimal object and display its value.
void CreateDecimal( int value, String^ valToStr )
{
   Decimal decimalNum = Decimal(value);
   
   // Format the constructor for display.
   String^ ctor = String::Format( "Decimal( {0} )", valToStr );
   
   // Display the constructor and its value.
   Console::WriteLine( "{0,-30}{1,16}", ctor, decimalNum );
}

int main()
{
   Console::WriteLine( "This example of the Decimal( int ) "
   "constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-30}{1,16}", "Constructor", "Value" );
   Console::WriteLine( "{0,-30}{1,16}", "-----------", "-----" );
   
   // Construct Decimal objects from int values.
   CreateDecimal( Int32::MinValue, "Int32::MinValue" );
   CreateDecimal( Int32::MaxValue, "Int32::MaxValue" );
   CreateDecimal( 0, "0" );
   CreateDecimal( 999999999, "999999999" );
   CreateDecimal( 0x40000000, "0x40000000" );
   CreateDecimal( (int)0xC0000000, "(int)0xC0000000" );
}

/*
This example of the Decimal( int ) constructor
generates the following output.

Constructor                              Value
-----------                              -----
Decimal( Int32::MinValue )         -2147483648
Decimal( Int32::MaxValue )          2147483647
Decimal( 0 )                                 0
Decimal( 999999999 )                 999999999
Decimal( 0x40000000 )               1073741824
Decimal( (int)0xC0000000 )         -1073741824
*/
//</Snippet1>
