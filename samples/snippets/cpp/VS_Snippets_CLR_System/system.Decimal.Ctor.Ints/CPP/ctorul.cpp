
//<Snippet4>
// Example of the Decimal( unsigned __int64 ) constructor.
using namespace System;

// Create a Decimal object and display its value.
void CreateDecimal( unsigned __int64 value, String^ valToStr )
{
   Decimal decimalNum = Decimal(value);
   
   // Format the constructor for display.
   String^ ctor = String::Format( "Decimal( {0} )", valToStr );
   
   // Display the constructor and its value.
   Console::WriteLine( "{0,-33}{1,22}", ctor, decimalNum );
}

int main()
{
   Console::WriteLine( "This example of the Decimal( unsigned "
   "__int64 ) constructor \ngenerates the following output.\n" );
   Console::WriteLine( "{0,-33}{1,22}", "Constructor", "Value" );
   Console::WriteLine( "{0,-33}{1,22}", "-----------", "-----" );
   
   // Construct Decimal objects from unsigned __int64 values.
   CreateDecimal( UInt64::MinValue, "UInt64::MinValue" );
   CreateDecimal( UInt64::MaxValue, "UInt64::MaxValue" );
   CreateDecimal( Int64::MaxValue, "Int64::MaxValue" );
   CreateDecimal( 999999999999999999, "999999999999999999" );
   CreateDecimal( 0x2000000000000000, "0x2000000000000000" );
   CreateDecimal( 0xE000000000000000, "0xE000000000000000" );
}

/*
This example of the Decimal( unsigned __int64 ) constructor
generates the following output.

Constructor                                       Value
-----------                                       -----
Decimal( UInt64::MinValue )                           0
Decimal( UInt64::MaxValue )        18446744073709551615
Decimal( Int64::MaxValue )          9223372036854775807
Decimal( 999999999999999999 )        999999999999999999
Decimal( 0x2000000000000000 )       2305843009213693952
Decimal( 0xE000000000000000 )      16140901064495857664
*/
//</Snippet4>
