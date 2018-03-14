//<Snippet1>
using namespace System;

void main()
{
        // Define an array of 64-bit integer values.
        array<Int64>^ values = { Int64::MinValue, Int64::MaxValue, 
                                 0xFFFFFFFFFFFF, 123456789123456789,
                                 -1000000000000000 };
        // Convert each value to a Decimal.
        for each (Int64 value in values) {
           Decimal decValue = value;
           Console::WriteLine("{0} ({1}) --> {2} ({3})", value,
                              value.GetType()->Name, decValue,
                              decValue.GetType()->Name);         
        }
}
// The example displays the following output:
//    -9223372036854775808 (Int64) --> -9223372036854775808 (Decimal)
//    9223372036854775807 (Int64) --> 9223372036854775807 (Decimal)
//    281474976710655 (Int64) --> 281474976710655 (Decimal)
//    123456789123456789 (Int64) --> 123456789123456789 (Decimal)
//    -1000000000000000 (Int64) --> -1000000000000000 (Decimal)
//</Snippet1>
