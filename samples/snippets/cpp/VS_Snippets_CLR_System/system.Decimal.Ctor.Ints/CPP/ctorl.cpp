
//<Snippet3>
// Example of the Decimal( __int64 ) constructor.
using namespace System;

// Create a Decimal object and display its value.
void CreateDecimal( __int64 value, String^ valToStr )
{
   Decimal decimalNum = Decimal(value);
   
   // Format the constructor for display.
   String^ ctor = String::Format( "Decimal( {0} )", valToStr );
   
   // Display the constructor and its value.
   Console::WriteLine( "{0,-35}{1,22}", ctor, decimalNum );
}

int main()
{
   Console::WriteLine( "This example of the Decimal( __int64 ) "
   "constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-35}{1,22}", "Constructor", "Value" );
   Console::WriteLine( "{0,-35}{1,22}", "-----------", "-----" );
   
   // Construct Decimal objects from __int64 values.
   CreateDecimal( Int64::MinValue, "Int64::MinValue" );
   CreateDecimal( Int64::MaxValue, "Int64::MaxValue" );
   CreateDecimal( 0, "0" );
   CreateDecimal( 999999999999999999, "999999999999999999" );
   CreateDecimal( 0x2000000000000000, "0x2000000000000000" );
   CreateDecimal( 0xE000000000000000, "0xE000000000000000" );
}

/*
This example of the Decimal( __int64 ) constructor
generates the following output.

Constructor                                         Value
-----------                                         -----
Decimal( Int64::MinValue )           -9223372036854775808
Decimal( Int64::MaxValue )            9223372036854775807
Decimal( 0 )                                            0
Decimal( 999999999999999999 )          999999999999999999
Decimal( 0x2000000000000000 )         2305843009213693952
Decimal( 0xE000000000000000 )        -2305843009213693952
*/
//</Snippet3>
