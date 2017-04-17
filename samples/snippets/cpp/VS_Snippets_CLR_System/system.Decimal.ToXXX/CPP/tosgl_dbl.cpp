
//<Snippet5>
// Example of the Decimal::ToSingle and Decimal::ToDouble methods.
using namespace System;
#define formatter "{0,30}{1,17}{2,23}"

// Convert the Decimal argument; no exceptions are thrown.
void DecimalToSgl_Dbl( Decimal argument )
{
   Object^ SingleValue;
   Object^ DoubleValue;
   
   // Convert the argument to a float value.
   SingleValue = Decimal::ToSingle( argument );
   
   // Convert the argument to a double value.
   DoubleValue = Decimal::ToDouble( argument );
   Console::WriteLine( formatter, argument, SingleValue, DoubleValue );
}

int main()
{
   Console::WriteLine( "This example of the \n"
   "  Decimal::ToSingle( Decimal ) and \n"
   "  Decimal::ToDouble( Decimal ) \nmethods "
   "generates the following output. It \ndisplays "
   "several converted Decimal values.\n" );
   Console::WriteLine( formatter, "Decimal argument", "float", "double" );
   Console::WriteLine( formatter, "----------------", "-----", "------" );
   
   // Convert Decimal values and display the results.
   DecimalToSgl_Dbl( Decimal::Parse(  "0.0000000000000000000000000001" ) );
   DecimalToSgl_Dbl( Decimal::Parse(  "0.0000000000123456789123456789" ) );
   DecimalToSgl_Dbl( Decimal::Parse(  "123" ) );
   DecimalToSgl_Dbl( Decimal(123000000,0,0,false,6) );
   DecimalToSgl_Dbl( Decimal::Parse(  "123456789.123456789" ) );
   DecimalToSgl_Dbl( Decimal::Parse(  "123456789123456789123456789" ) );
   DecimalToSgl_Dbl( Decimal::MinValue );
   DecimalToSgl_Dbl( Decimal::MaxValue );
}

/*
This example of the
  Decimal::ToSingle( Decimal ) and
  Decimal::ToDouble( Decimal )
methods generates the following output. It
displays several converted Decimal values.

              Decimal argument            float                 double
              ----------------            -----                 ------
0.0000000000000000000000000001            1E-28                  1E-28
0.0000000000123456789123456789     1.234568E-11   1.23456789123457E-11
                           123              123                    123
                    123.000000              123                    123
           123456789.123456789     1.234568E+08       123456789.123457
   123456789123456789123456789     1.234568E+26   1.23456789123457E+26
-79228162514264337593543950335    -7.922816E+28  -7.92281625142643E+28
 79228162514264337593543950335     7.922816E+28   7.92281625142643E+28
*/
//</Snippet5>
