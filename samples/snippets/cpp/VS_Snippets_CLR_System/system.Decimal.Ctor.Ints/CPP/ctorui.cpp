
//<Snippet2>
// Example of the Decimal( unsigned int ) constructor.
using namespace System;

// Create a Decimal object and display its value.
void CreateDecimal( unsigned int value, String^ valToStr )
{
   Decimal decimalNum = Decimal(value);
   
   // Format the constructor for display.
   String^ ctor = String::Format( "Decimal( {0} )", valToStr );
   
   // Display the constructor and its value.
   Console::WriteLine( "{0,-30}{1,16}", ctor, decimalNum );
}

int main()
{
   Console::WriteLine( "This example of the Decimal( unsigned "
   "int ) constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-30}{1,16}", "Constructor", "Value" );
   Console::WriteLine( "{0,-30}{1,16}", "-----------", "-----" );
   
   // Construct Decimal objects from unsigned int values.
   CreateDecimal( UInt32::MinValue, "UInt32::MinValue" );
   CreateDecimal( UInt32::MaxValue, "UInt32::MaxValue" );
   CreateDecimal( Int32::MaxValue, "Int32::MaxValue" );
   CreateDecimal( 999999999, "999999999" );
   CreateDecimal( 0x40000000, "0x40000000" );
   CreateDecimal( 0xC0000000, "0xC0000000" );
}

/*
This example of the Decimal( unsigned int ) constructor
generates the following output.

Constructor                              Value
-----------                              -----
Decimal( UInt32::MinValue )                  0
Decimal( UInt32::MaxValue )         4294967295
Decimal( Int32::MaxValue )          2147483647
Decimal( 999999999 )                 999999999
Decimal( 0x40000000 )               1073741824
Decimal( 0xC0000000 )               3221225472
*/
//</Snippet2>
