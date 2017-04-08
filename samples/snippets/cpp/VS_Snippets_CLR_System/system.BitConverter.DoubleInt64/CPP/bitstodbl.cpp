
//<Snippet1>
// Example of the BitConverter::Int64BitsToDouble method.
using namespace System;

// Reinterpret the __int64 argument as a double.
void LongBitsToDouble( __int64 argument )
{
   double doubleValue;
   doubleValue = BitConverter::Int64BitsToDouble( argument );
   
   // Display the argument in hexadecimal.
   Console::WriteLine( "{0,20}{1,27:E16}", String::Format( "0x{0:X16}", argument ), doubleValue );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::Int64BitsToDouble( "
   "__int64 ) \nmethod generates the following output.\n" );
   Console::WriteLine( "{0,20}{1,27:E16}", "__int64 argument", "double value" );
   Console::WriteLine( "{0,20}{1,27:E16}", "----------------", "------------" );
   
   // Convert __int64 values and display the results.
   LongBitsToDouble( 0 );
   LongBitsToDouble( 0x3FF0000000000000 );
   LongBitsToDouble( 0x402E000000000000 );
   LongBitsToDouble( 0x406FE00000000000 );
   LongBitsToDouble( 0x41EFFFFFFFE00000 );
   LongBitsToDouble( 0x3F70000000000000 );
   LongBitsToDouble( 0x3DF0000000000000 );
   LongBitsToDouble( 0x0000000000000001 );
   LongBitsToDouble( 0x000000000000FFFF );
   LongBitsToDouble( 0x0000FFFFFFFFFFFF );
   LongBitsToDouble( 0xFFFFFFFFFFFFFFFF );
   LongBitsToDouble( 0xFFF0000000000000 );
   LongBitsToDouble( 0x7FF0000000000000 );
   LongBitsToDouble( 0xFFEFFFFFFFFFFFFF );
   LongBitsToDouble( 0x7FEFFFFFFFFFFFFF );
   LongBitsToDouble( Int64::MinValue );
   LongBitsToDouble( Int64::MaxValue );
}

/*
This example of the BitConverter::Int64BitsToDouble( __int64 )
method generates the following output.

    __int64 argument               double value
    ----------------               ------------
  0x0000000000000000    0.0000000000000000E+000
  0x3FF0000000000000    1.0000000000000000E+000
  0x402E000000000000    1.5000000000000000E+001
  0x406FE00000000000    2.5500000000000000E+002
  0x41EFFFFFFFE00000    4.2949672950000000E+009
  0x3F70000000000000    3.9062500000000000E-003
  0x3DF0000000000000    2.3283064365386963E-010
  0x0000000000000001    4.9406564584124654E-324
  0x000000000000FFFF    3.2378592100206092E-319
  0x0000FFFFFFFFFFFF    1.3906711615669959E-309
  0xFFFFFFFFFFFFFFFF                        NaN
  0xFFF0000000000000                  -Infinity
  0x7FF0000000000000                   Infinity
  0xFFEFFFFFFFFFFFFF   -1.7976931348623157E+308
  0x7FEFFFFFFFFFFFFF    1.7976931348623157E+308
  0x8000000000000000    0.0000000000000000E+000
  0x7FFFFFFFFFFFFFFF                        NaN
*/
//</Snippet1>
